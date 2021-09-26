using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using JohariWindow.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JohariWindow.Pages.Client
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public ClientResponseViewModel ClientResponseVM { get; set; }


        private IEnumerable<ClientResponse> PreviousResponses = null;
        public List<Adjective> Adjectives;


        public IndexModel(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public IActionResult OnGet(int? clientID)
        {
            if (!clientID.HasValue || !_unitOfWork.Client.List().Any(i => i.ClientID == clientID))
            {
                return NotFound();
            }

            LoadPreviousResponses(clientID.Value);
            LoadVM(clientID.Value);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            LoadPreviousResponses(ClientResponseVM.Client.ClientID);
            DeletePreviousResponses();
            SaveResponses();
            _unitOfWork.Commit();

            return RedirectToPage("../Index");
        }

        /// <summary>
        /// Populates the VM and other model data.
        /// </summary>
        /// <param name="clientID">ID of the client the information will go off of.</param>
        private void LoadVM(int clientID)
        {
            Adjectives = _unitOfWork.Adjective.List().OrderBy(i => i.AdjName).ToList();
            var client = _unitOfWork.Client.Get(x => x.ClientID == clientID, true);
            ClientResponseVM = new ClientResponseViewModel()
            {
                Client = client,
                Adjectives = Adjectives.Select(x => new SelectListItem
                {
                    Text = x.AdjName,
                    Value = x.AdjectiveID.ToString(),
                    Selected = PreviousResponses != null && PreviousResponses.Select(x => x.AdjectiveID).Contains(x.AdjectiveID)
                }).ToList()
            };
        }

        /// <summary>
        /// Loads the previous responses. Used for showing what was previously selected or deleting previous entries.
        /// </summary>
        /// <param name="clientID">Client ID that responses are for.</param>
        private void LoadPreviousResponses(int clientID)
        {
            PreviousResponses = _unitOfWork.ClientResponse.List(x => x.ClientID == clientID);
        }

        /// <summary>
        /// Deletes previous responses in the database.
        /// </summary>
        private void DeletePreviousResponses()
        {
            if (PreviousResponses != null)
            {
                foreach (var response in PreviousResponses)
                {
                    _unitOfWork.ClientResponse.Delete(response);
                }
            }
        }

        /// <summary>
        /// Saves the users new selections.
        /// </summary>
        private void SaveResponses()
        {
            var responsesToSave = ClientResponseVM.Adjectives.Where(i => i.Selected).Select(x => new ClientResponse { ClientID = ClientResponseVM.Client.ClientID, AdjectiveID = Convert.ToInt32(x.Value) });
            foreach (var response in responsesToSave)
            {
                _unitOfWork.ClientResponse.Add(response);
            }
        }
    }
}

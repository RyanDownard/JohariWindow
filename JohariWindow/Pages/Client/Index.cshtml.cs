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

        //Used to check against any previous responses saved
        private List<ClientResponse> PreviousResponses = null;
        public List<Adjective> AllAdjectives;
        public ApplicationCore.Models.Client Client;

        public IndexModel(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public IActionResult OnGet(int? clientID)
        {
            if (!clientID.HasValue || !_unitOfWork.Client.List().Any(i => i.ClientID == clientID))
            {
                return NotFound();
            }

            ClientResponseVM = new ClientResponseViewModel();
            LoadClient(clientID.Value);
            LoadPreviousResponses(clientID.Value);
            LoadAdjectives();
            ClientResponseVM.ClientID = clientID.Value;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            LoadPreviousResponses(ClientResponseVM.ClientID);
            DeletePreviousResponses();
            SaveResponses();
            _unitOfWork.Commit();

            return RedirectToPage("../Index");
        }

        /// <summary>
        /// Populates the VM and other model data.
        /// </summary>
        private void LoadAdjectives()
        {
            AllAdjectives = _unitOfWork.Adjective.List().OrderBy(i => i.AdjName).ToList();
            ClientResponseVM.PositiveAdjectives = AllAdjectives.Where(i => i.AdjType).Select
                (x =>
                    new SelectListItem
                    {
                        Text = x.AdjName,
                        Value = x.AdjectiveID.ToString(),
                        Selected = PreviousResponses.Any(i => i.AdjectiveID == x.AdjectiveID)
                    }
                ).ToList();
            ClientResponseVM.NegativeAdjectives = AllAdjectives.Where(i => !i.AdjType).Select
                (x =>
                    new SelectListItem
                    {
                        Text = x.AdjName,
                        Value = x.AdjectiveID.ToString(),
                        Selected = PreviousResponses.Any(i => i.AdjectiveID == x.AdjectiveID)
                    }
                ).ToList();
        }

        private void LoadClient(int clientID)
        {
            Client = _unitOfWork.Client.Get(i => i.ClientID == clientID);
        }

        /// <summary>
        /// Loads the previous responses. Used for showing what was previously selected or deleting previous entries.
        /// </summary>
        /// <param name="clientID">Client ID that responses are for.</param>
        private void LoadPreviousResponses(int clientID)
        {
            PreviousResponses = _unitOfWork.ClientResponse.List(x => x.ClientID == clientID).ToList();
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
            var responsesToSave = ClientResponseVM.PositiveAdjectives.Where(i => i.Selected)
                .Select(x => new ClientResponse { ClientID = ClientResponseVM.ClientID, AdjectiveID = Convert.ToInt32(x.Value) }).ToList();
            responsesToSave.AddRange(ClientResponseVM.NegativeAdjectives.Where(i => i.Selected)
                .Select(x => new ClientResponse { ClientID = ClientResponseVM.ClientID, AdjectiveID = Convert.ToInt32(x.Value) }));
            foreach (var response in responsesToSave)
            {
                _unitOfWork.ClientResponse.Add(response);
            }
        }
    }
}

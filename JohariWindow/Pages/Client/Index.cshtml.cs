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

        public List<Adjective> AllAdjectives;
        public ApplicationCore.Models.Client Client;

        public IndexModel(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public IActionResult OnGet(int? clientID)
        {
            if (!clientID.HasValue || !_unitOfWork.Client.List().Any(i => i.ClientID == clientID))
            {
                return NotFound();
            }

            if(_unitOfWork.ClientResponse.List(i => i.ClientID == clientID).Any())
            {
                return RedirectToPage("/Client/ResponseSubmitted");
            }

            ClientResponseVM = new ClientResponseViewModel();
            LoadClient(clientID.Value);
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
            SaveResponses();
            _unitOfWork.Commit();

            return RedirectToPage("/Client/Thanks");
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
                        Value = x.AdjectiveID.ToString()
                    }
                ).ToList();
            ClientResponseVM.NegativeAdjectives = AllAdjectives.Where(i => !i.AdjType).Select
                (x =>
                    new SelectListItem
                    {
                        Text = x.AdjName,
                        Value = x.AdjectiveID.ToString()
                    }
                ).ToList();
        }

        private void LoadClient(int clientID)
        {
            Client = _unitOfWork.Client.Get(i => i.ClientID == clientID);
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

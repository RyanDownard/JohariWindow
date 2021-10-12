using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using JohariWindow.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JohariWindow.Pages.Admin
{
    public class WindowModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public ApplicationCore.Models.Client Client;
        public bool ValidWindow;
        public List<FriendResponse> FriendResponses;
        List<ClientResponse> ClientResponses;
        public WindowViewModel WindowVM;
        public WindowModel(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;


        public void OnGet(int ClientID)
        {
            Client = _unitOfWork.Client.Get(i => i.ClientID == ClientID);
            var adjectives = _unitOfWork.Adjective.List();
            ClientResponses = _unitOfWork.ClientResponse.List(i => i.ClientID == ClientID, null, "Adjective").ToList();
            FriendResponses = _unitOfWork.FriendResponse.List(i => i.ClientID == ClientID, null, "Adjective").ToList();
            ValidWindow = ClientResponses.Any() && FriendResponses.Any();
            if (ValidWindow)
            {
                WindowVM = new WindowViewModel();
                WindowVM.OpenSelf = (from c in ClientResponses
                                     join f in FriendResponses on c.AdjectiveID equals f.AdjectiveID into gj
                                     from gjf in gj.DefaultIfEmpty()
                                     where gjf is not null
                                     select c.Adjective.AdjName).Distinct().OrderBy(i => i).ToList();

                WindowVM.BlindSelf = (from f in FriendResponses
                                      join c in ClientResponses on f.AdjectiveID equals c.AdjectiveID into gj
                                      from gjc in gj.DefaultIfEmpty()
                                      where gjc is null
                                      select f.Adjective.AdjName).Distinct().OrderBy(i => i).ToList();

                WindowVM.HiddenSelf = (from c in ClientResponses
                                       join f in FriendResponses on c.AdjectiveID equals f.AdjectiveID into gj
                                       from gjf in gj.DefaultIfEmpty()
                                       where gjf is null
                                       select c.Adjective.AdjName).Distinct().OrderBy(i => i).ToList();
                WindowVM.UnknownSelf = adjectives.Where(i =>
                                        !WindowVM.OpenSelf.Contains(i.AdjName)
                                        &&
                                        !WindowVM.BlindSelf.Contains(i.AdjName)
                                        &&
                                        !WindowVM.HiddenSelf.Contains(i.AdjName)).Select(x => x.AdjName).OrderBy(i => i).ToList();
            }
        }
    }
}

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
    public class FriendModel : PageModel
    {
        [BindProperty]
        public FriendResponseViewModel FriendResponseVM { get; set; }
        public ApplicationCore.Models.Client Client;
        public List<Adjective> AllAdjectives;
        private Friend Friend;
        private readonly IUnitOfWork _unitOfWork;
        public FriendModel(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork; 
        public IActionResult OnGet(int clientID, int invitedFriendID)
        {
            if (!_unitOfWork.Client.List().Any(i => i.ClientID == clientID) || !_unitOfWork.InvitedFriend.List().Any(i => i.InvitedFriendID == invitedFriendID))
            {
                return NotFound();
            }

            if(_unitOfWork.InvitedFriend.List().Any(i => i.InvitedFriendID == invitedFriendID && i.Accepted))
            {
                return BadRequest();
            }
            Client = _unitOfWork.Client.Get(i => i.ClientID == clientID);
            FriendResponseVM = new FriendResponseViewModel
            {
                ClientID = clientID,
                InvitedFriendID = invitedFriendID
            };
            LoadAdjectives();
            return Page();
        }

        public IActionResult OnPost()
        { 
             if (!ModelState.IsValid)
            {
                return Page();
            }
            MarkedFriendAsAccepted();
            SaveFriend();
            SaveFriendResponses();
            return RedirectToPage("/Client/Thanks");
        }

        /// <summary>
        /// Mark that a friend has accepted the invite and submitted a response
        /// </summary>
        private void MarkedFriendAsAccepted()
        {
            var invitedFriend = _unitOfWork.InvitedFriend.Get(i => i.InvitedFriendID == FriendResponseVM.InvitedFriendID);
            invitedFriend.Accepted = true;
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Saves the friend so we have a reference for it
        /// </summary>
        private void SaveFriend()
        {
            Friend = new Friend
            {
                HowLong = FriendResponseVM.HowLong,
                Relationship = FriendResponseVM.Relationship
            };
            _unitOfWork.Friend.Add(Friend);
            //have to commit early so we get the friend
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Saves all the responses from a friend
        /// </summary>
        private void SaveFriendResponses()
        {
            var responsesToSave = FriendResponseVM.PositiveAdjectives.Where(i => i.Selected)
                .Select(x => new FriendResponse { ClientID = FriendResponseVM.ClientID, AdjectiveID = Convert.ToInt32(x.Value), FriendID = Friend.FriendID }).ToList();
            responsesToSave.AddRange(FriendResponseVM.NegativeAdjectives.Where(i => i.Selected)
                .Select(x => new FriendResponse { ClientID = FriendResponseVM.ClientID, AdjectiveID = Convert.ToInt32(x.Value), FriendID = Friend.FriendID }));
            foreach (var response in responsesToSave)
            {
                _unitOfWork.FriendResponse.Add(response);
            }
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Populates the VM and other model data.
        /// </summary>
        private void LoadAdjectives()
        {
            AllAdjectives = _unitOfWork.Adjective.List().OrderBy(i => i.AdjName).ToList();
            FriendResponseVM.PositiveAdjectives = AllAdjectives.Where(i => i.AdjType).Select
                (x =>
                    new SelectListItem
                    {
                        Text = x.AdjName,
                        Value = x.AdjectiveID.ToString()
                    }
                ).ToList();
            FriendResponseVM.NegativeAdjectives = AllAdjectives.Where(i => !i.AdjType).Select
                (x =>
                    new SelectListItem
                    {
                        Text = x.AdjName,
                        Value = x.AdjectiveID.ToString()
                    }
                ).ToList();
        }
    }
}

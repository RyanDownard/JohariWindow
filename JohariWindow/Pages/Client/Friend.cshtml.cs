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
        public List<SelectListItem> Relationships;
        public List<SelectListItem> Times;
        private Friend Friend;
        private readonly IUnitOfWork _unitOfWork;
        public FriendModel(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        public IActionResult OnGet(int clientID, int invitedFriendID)
        {
            if (!_unitOfWork.Client.List().Any(i => i.ClientID == clientID) || !_unitOfWork.InvitedFriend.List().Any(i => i.InvitedFriendID == invitedFriendID))
            {
                return NotFound();
            }

            if (_unitOfWork.InvitedFriend.List().Any(i => i.InvitedFriendID == invitedFriendID && i.Accepted))
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
            LoadRelationships();
            LoadTimes();
            return Page();
        }

        private void LoadTimes()
        {
            Times = new List<SelectListItem>
            {
                new SelectListItem{ Text = "0-12 Months", Value = "0-12 Months" },
                new SelectListItem{ Text = "1 Year", Value = "1 Year" },
                new SelectListItem{ Text = "2 Years", Value = "2 Years" },
                new SelectListItem{ Text = "3-5 Years", Value = "3-5 Years" },
                new SelectListItem{ Text = "5-10 Years", Value = "5-10 Years" },
                new SelectListItem{ Text = "10+ Years", Value = "10 + Years" }
            };
        }

        private void LoadRelationships()
        {
            Relationships = new List<SelectListItem>
            {
                new SelectListItem { Text = "Acquaintance", Value = "Acquaintance"},
                new SelectListItem{ Text = "Coworker", Value = "Coworker" },
                new SelectListItem{ Text = "Friend", Value = "Friend" },
                new SelectListItem{ Text = "Neighbor", Value = "Neighbor" },
                new SelectListItem{ Text = "Parent", Value = "Parent" },
                new SelectListItem{ Text = "Sibling", Value = "Sibling" }
            };
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

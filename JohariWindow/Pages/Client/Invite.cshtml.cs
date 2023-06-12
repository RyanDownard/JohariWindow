using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JohariWindow.Pages.Client
{
    public class InviteModel : PageModel
    {
        [BindProperty]
        public List<string> Emails { get; set; }
        [BindProperty]
        public int ClientID { get; set; }
        private readonly IEmailSender _emailSender;
        private readonly IUnitOfWork _unitOfWork;
        public InviteModel(IEmailSender emailSender, IUnitOfWork unitOfWork)
        {
            _emailSender = emailSender;
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int clientID)
        {
            ClientID = clientID;
        }

        public IActionResult OnPost()
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
            var client = _unitOfWork.Client.Get(i => i.ClientID == ClientID);
            var subject = $"Johari Window Invite - {client.FirstName} {client.LastName}";
            var initialMessage = $"You have been invited to by {client.FirstName} {client.LastName} to help compile a Johari Window.";

            foreach(var email in Emails)
            {
                var invitedFriend = new InvitedFriend { Email = email, ClientID = ClientID };
                _unitOfWork.InvitedFriend.Add(invitedFriend);
                _unitOfWork.Commit();
                //now that the friend has been saved, we can email.
                _emailSender.SendEmailAsync(email, subject, $"{initialMessage} <a href='{baseUrl}/Client/Friend/{ClientID}/{invitedFriend.InvitedFriendID}'>Click here to accept the invite and describe their personality.</a>");
            }
            return RedirectToPage("/Index");
        }
    }
}

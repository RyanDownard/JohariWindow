using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JohariWindow.Pages.Admin
{
    public class IndexModel : PageModel
    {
        IUnitOfWork _unitOfWork;
        public List<ApplicationCore.Models.Client> Clients;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGet()
        {
            if (!User.IsInRole(StaticDetails.AdminRole))
            {
                return BadRequest();
            }
            Clients = _unitOfWork.Client.List(null, null, "InvitedFriends,ApplicationUser").ToList();
            List<int> clientsToRemove = new List<int>();
            foreach(var client in Clients)
            {
                if (client.ApplicationUser != null)
                {
                    var roles = await _userManager.GetRolesAsync(client.ApplicationUser);
                    if (roles.Contains(StaticDetails.AdminRole))
                    {
                        clientsToRemove.Add(client.ClientID);
                    }
                }
            }
            if (clientsToRemove.Any())
            {
                Clients.RemoveAll(i => clientsToRemove.Contains(i.ClientID));
            }
            return Page();
        }
    }
}

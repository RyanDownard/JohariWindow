using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JohariWindow.Pages.Admin
{
    public class IndexModel : PageModel
    {
        IUnitOfWork _unitOfWork;
        public List<ApplicationCore.Models.Client> Clients;

        public IndexModel(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public IActionResult OnGet()
        {
            if (!User.IsInRole(StaticDetails.AdminRole))
            {
                return NotFound();
            }
            Clients = _unitOfWork.Client.List(null, null, "InvitedFriends").ToList();
            return Page();
        }
    }
}

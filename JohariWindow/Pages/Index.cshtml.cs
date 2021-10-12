using ApplicationCore.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohariWindow.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(ILogger<IndexModel> logger, UserManager<ApplicationUser> UserManager)
        {
            _logger = logger;
            _userManager = UserManager;
        }

        public async Task<IActionResult> OnGet()
        {
            if (User.IsInRole(StaticDetails.AdminRole))
            {
                return RedirectToPage("Admin/Index");
            }
            else if(User.IsInRole(StaticDetails.UserRole))
            {
                var appUser = await _userManager.GetUserAsync(User);
                return RedirectToPage("Client/Index", new { ClientID = appUser.ClientID });
            }
            else
            {
                return Page();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JohariWindow.Pages.Client
{
    public class InviteModel : PageModel
    {
        [BindProperty]
        public List<string> Emails { get; set; }
        public void OnGet()
        {
        }
    }
}

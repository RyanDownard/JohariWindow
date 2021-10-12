using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JohariWindow.Pages.Admin
{
    public class WindowModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public ApplicationCore.Models.Client Client;
        public WindowModel(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;


        public void OnGet(int ClientID)
        {
            Client = _unitOfWork.Client.Get(i => i.ClientID == ClientID);
        }
    }
}

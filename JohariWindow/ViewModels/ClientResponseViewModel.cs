using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohariWindow.ViewModels
{
    public class ClientResponseViewModel : ResponseViewModel
    {
        public int ClientID { get; set; }

    }
}

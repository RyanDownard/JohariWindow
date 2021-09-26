using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohariWindow.ViewModels
{
    public class ClientResponseViewModel
    {
        public Client Client { get; set; }
        public List<SelectListItem> Adjectives { get; set; }
    }
}

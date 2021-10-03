using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohariWindow.ViewModels
{
    public class ResponseViewModel
    {
        public List<SelectListItem> PositiveAdjectives { get; set; }
        public List<SelectListItem> NegativeAdjectives { get; set; }
    }
}

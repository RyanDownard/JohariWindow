using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohariWindow.ViewModels
{
    public class WindowViewModel
    {
        public List<Adjective> OpenSelf { get; set; }
        public List<Adjective> BlindSelf { get; set; }
        public List<Adjective> HiddenSelf { get; set; }
        public List<Adjective> UnknownSelf { get; set; }
    }
}

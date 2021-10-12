using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohariWindow.ViewModels
{
    public class WindowViewModel
    {
        public List<string> OpenSelf { get; set; }
        public List<string> BlindSelf { get; set; }
        public List<string> HiddenSelf { get; set; }
        public List<string> UnknownSelf { get; set; }
    }
}

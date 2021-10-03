using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JohariWindow.ViewModels
{
    public class FriendResponseViewModel : ResponseViewModel
    {
        public int ClientID { get; set; }
        public int InvitedFriendID { get; set; }
        public string Relationship { get; set; }
        [Display(Name = "How Long")]
        public string HowLong { get; set; }
    }
}

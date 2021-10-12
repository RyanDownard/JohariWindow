using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApplicationCore.Models
{
    public class InvitedFriend
    {
        [Key]
        public int InvitedFriendID { get; set; }
        public int ClientID { get; set; }
        public string Email { get; set; }
        public bool Accepted { get; set; }

        //[ForeignKey("ClientID")]
        //public Client Client { get; set; }
    }
}

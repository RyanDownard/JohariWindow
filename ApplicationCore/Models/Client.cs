using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApplicationCore.Models
{
    public class Client
    {
        [Key]
        public int ClientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }

        [NotMapped]
        public string FullName { get { return FirstName + " " + LastName; } }

        [ForeignKey("ClientID")]
        public virtual List<InvitedFriend> InvitedFriends { get; set; }

        [InverseProperty("Client")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}

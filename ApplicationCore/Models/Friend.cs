using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.Models
{
    public class Friend
    {
        [Key]
        public int FriendID { get; set; }
        public string Relationship { get; set; }
        public string HowLong { get; set; }
    }
}

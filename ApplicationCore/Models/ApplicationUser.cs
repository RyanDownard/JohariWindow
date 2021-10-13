using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApplicationCore.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int ClientID { get; set; }

        [ForeignKey("ClientID")]
        public virtual Client Client { get; set; }
    }
}

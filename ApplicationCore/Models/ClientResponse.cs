using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApplicationCore.Models
{
    public class ClientResponse
    {
        [Key]
        public int ResponseID { get; set; }
        public int AdjectiveID { get; set; }
        public int ClientID { get; set; }

        [ForeignKey("ClientID")]
        public virtual Client Client { get; set; }
        [ForeignKey("AdjectiveID")]
        public virtual Adjective Adjective { get; set; }
    }
}

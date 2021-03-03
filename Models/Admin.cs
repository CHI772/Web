using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Admin
    {
        [Key]
        public string AID { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string APassword { get; set; }

        public string AName { get; set; }
    }
}
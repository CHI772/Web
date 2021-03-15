using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.ViewModel
{
    public class A_LoginViewModel
    {
        [Required]
        public string AID { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string APassword { get; set; }
    }
}
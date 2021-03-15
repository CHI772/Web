using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.ViewModel
{
    public class T_LoginViewModel
    {
        [Required]
        public string TID { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string TPassword { get; set; }
    }
}
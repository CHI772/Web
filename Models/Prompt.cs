using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class Prompt
    {
        [Key]
        [Column(Order = 0)]
        public int PID { get; set; }


        [Required]
        public string PContent { get; set; }

        [Key]
        [Column(Order = 1)]
        public string MID { get; set; }


        public virtual Mission Mission { get; set; }
    }
}
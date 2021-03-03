using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Web.Models
{
    public class StudentGroup
    {
        [Key]
        [Column(Order = 0)]
        public string SID { get; set; }

        [Key]
        [Column(Order = 1)]
        public string MID { get; set; }

        public virtual Student Student { get; set; }
        public virtual Mission Mission { get; set; }
    }
}
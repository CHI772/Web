using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Web.Models
{
    public class Course
    {
        public Course()
        {
            Missions = new HashSet<Mission>();
        }
        [Key]
        [Column(Order = 0)]
        [Display(Name ="ID")]
        public string CID { get; set; }


        [Required]
        [Display(Name = "課程名稱")]
        public string CName { get; set; }

        [Key]
        [Column(Order = 1)]
        public string TID { get; set; }


        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Mission> Missions { get; set; }
    }
}
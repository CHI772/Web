using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class TeacherAssessment
    {
        [Key]
        [Column(Order = 0)]
        public int TEID { get; set; }

        [Required]
        public string TeacherA { get; set; }


        [Required]
        public int GroupAchievementLevel { get; set; }

        [Key]
        [Column(Order = 1)]
        public string MID { get; set; }

        [Key]
        [Column(Order = 2)]
        public string GID { get; set; }

        public virtual Mission Mission { get; set; }

        public virtual Group Group { get; set; }
    }
}
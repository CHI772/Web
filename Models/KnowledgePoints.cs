using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class KnowledgePoints
    {
        public KnowledgePoints()
        {
            Missions = new HashSet<Mission>();
        }
        [Key]
        [Column(Order = 0)]
        public int KID { get; set; }

        [Required]
        public string KContent { get; set; }

        [Key]
        [Column(Order = 1)]
        public string MID { get; set; }

        public virtual Mission Mission { get; set; }
        public virtual ICollection<Mission> Missions { get; set; }
    }
}
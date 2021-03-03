using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class MissionKnowledgePoints
    {
        [Key]
        [Column(Order = 0)]
        public string KID { get; set; }

        [Key]
        [Column(Order = 1)]
        public string MID { get; set; }

        public virtual KnowledgePoints KnowledgePoints { get; set; }
        public virtual Mission Mission { get; set; }
    }
}
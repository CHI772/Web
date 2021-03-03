using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class Mission
    {
        public Mission()
        {
            Groups = new HashSet<Group>();
            KnowledgePoint = new HashSet<KnowledgePoints>();
            Prompts = new HashSet<Prompt>();
            SelfAssessments = new HashSet<SelfAssessment>();
            PeerAssessments = new HashSet<PeerAssessment>();
            LearnB = new HashSet<LearningBehavior>();
            TeacherA = new HashSet<TeacherAssessment>();
        }

        [Key]
        [Column(Order = 0)]
        public string MID { get; set; }


        [Required]
        public string MName { get; set; }


        [Required]
        public string MDetail { get; set; }

        [Key]
        [Column(Order = 1)]
        public string CID { get; set; }


        public virtual Course Course { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<KnowledgePoints> KnowledgePoint { get; set; }
        public virtual ICollection<Prompt> Prompts { get; set; }
        public virtual ICollection<SelfAssessment> SelfAssessments { get; set; }
        public virtual ICollection<PeerAssessment> PeerAssessments { get; set; }
        public virtual ICollection<LearningBehavior> LearnB { get; set; }
        public virtual ICollection<TeacherAssessment> TeacherA { get; set; }
           
    }
}
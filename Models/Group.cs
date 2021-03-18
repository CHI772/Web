using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class Group
    {
        public Group()
        {
            Students = new HashSet<Student>();
            Prompts = new HashSet<Prompt>();
            SelfAssessments = new HashSet<SelfAssessment>();
            PeerAssessments = new HashSet<PeerAssessment>();
            LearnB = new HashSet<LearningBehavior>();
            TeacherA = new HashSet<TeacherAssessment>();
        }

        [Display(Name = "組別編號")]
        public int GID { get; set; }

        [Key]
        [Required]
        [Column(Order = 0)]
        [Display(Name = "組別名稱")]
        public string GName { get; set; }

        [Required]
        [Display(Name ="職位")]
        public string Position { get; set; }

        [Key]
        [Column(Order = 1)]
        [Display(Name = "任務編號")]
        public string MID { get; set; }

        public virtual Mission Mission { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Prompt> Prompts { get; set; }
        public virtual ICollection<SelfAssessment> SelfAssessments { get; set; }
        public virtual ICollection<PeerAssessment> PeerAssessments { get; set; }
        public virtual ICollection<LearningBehavior> LearnB { get; set; }
        public virtual ICollection<TeacherAssessment> TeacherA { get; set; }
    }
}
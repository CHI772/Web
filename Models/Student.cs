using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class Student
    {
        public Student()
        {
            Groups = new HashSet<Group>();
            Prompts = new HashSet<Prompt>();
            SelfAssessments = new HashSet<SelfAssessment>();
            PeerAssessments = new HashSet<PeerAssessment>();
            LearnB = new HashSet<LearningBehavior>();
        }

        [Key]
        [Column(Order = 0)]
        public string SID { get; set; }


        [Required]
        public string SName { get; set; }


        [Required]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string SPassword { get; set; }


        [Required]
        public Boolean Sex { get; set; }


        [Required]
        [Display(Name = "教育階段")]
        public string Stage { get; set; }


        [Required]
        [Display(Name = "年級")]
        public string Grade { get; set; }


        [Key]
        [Column(Order = 1)]
        public string CID { get; set; }


        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Prompt> Prompts { get; set; }
        public virtual ICollection<SelfAssessment> SelfAssessments { get; set; }
        public virtual ICollection<PeerAssessment> PeerAssessments { get; set; }
        public virtual ICollection<LearningBehavior> LearnB { get; set; }
        
    }
}
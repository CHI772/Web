using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //資料欄位和參數關聯的資料類型 

namespace Web.Models
{
    public class Teacher
    {
        public Teacher()
        {
            Courses = new HashSet<Course>();
        }

        [Key]
        [Required]  //不可為 null
        [Display(Name = "教師編號")]
        public string TID { get; set; }


        [Required]
        public string TName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string TPassword { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
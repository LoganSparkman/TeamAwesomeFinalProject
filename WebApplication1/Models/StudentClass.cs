using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class StudentClass
    {
        [Key]
        public int StudentClassID { get; set; }


        [Display(Name = "Class")]
        [Required]
        public int ClassID { get; set; }
        [ForeignKey("ClassID")]
        public virtual Class Class { get; set; }

        [Required]
        [Display(Name = "Student")]
        public int StudentID { get; set; }
        [ForeignKey("StudentID")]
        public virtual Student Student { get; set; }
    }
}

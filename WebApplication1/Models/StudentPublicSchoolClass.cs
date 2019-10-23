using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class StudentPublicSchoolClass
    {
        [Key]
        public int StudentPublicSchoolClassID { get; set; }
        [StringLength(500)]
        public string CourseName { get; set; }

        [Display(Name = "Student")]
        [Required]
        public int StudentID { get; set; }
        [ForeignKey("StudentID")]
        public virtual Student Student { get; set; }
    }
}

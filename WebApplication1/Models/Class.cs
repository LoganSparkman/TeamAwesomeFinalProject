using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Class
    {
        [Key]
        public int ClassID { get; set; }
        [Required]
        public Int16 Capacity { get; set; }
        //FKs Below

        [Display(Name = "Course")]
        [Required]
        public int CourseID { get; set; }
        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }

        [Display(Name = "Term")]
        [Required]
        public int TermID { get; set; }
        [ForeignKey("TermID")]
        public virtual Term Term { get; set; }
    }
}

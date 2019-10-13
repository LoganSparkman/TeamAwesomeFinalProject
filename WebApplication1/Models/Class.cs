using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Class
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Class Name")]
        public string ClassName { get; set; }
        [Required]
        [Display(Name = "Class Subject")]
        public string ClassSubject { get; set; }
        [Required]
        [Display(Name = "Cousrse Number")]
        public string CourseNumber { get; set; }

    }
}

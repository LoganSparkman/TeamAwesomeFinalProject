using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        [Required]
        [StringLength(500)]
        public string Name { get; set; }
    }
}

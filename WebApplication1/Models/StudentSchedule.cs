using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class StudentSchedule
    {
        [Required]
        [Display(Name = "Schedule")]
        public int ClassScheduleID { get; set; }
        [ForeignKey("ClassScheduleID")]
        public virtual ClassSchedule ClassSchedule { get; set; }

        [Required]
        [Display(Name = "Student")]
        public int StudentID { get; set; }
        [ForeignKey("StudentID")]
        public virtual Student Student { get; set; }
    }
}

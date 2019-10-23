using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ClassSchedule
    {
        [Key]
        public int ClassScheduleID {get; set;}

        [Display(Name = "Class")]
        [Required]
        public int ClassID { get; set; }
        [ForeignKey("ClassID")]
        public virtual Class Class { get; set; }

        [Display(Name = "Schedule")]
        [Required]
        public int ScheduleID { get; set; }
        [ForeignKey("ScheduleID")]
        public virtual Schedule Schedule { get; set; }
    }
}

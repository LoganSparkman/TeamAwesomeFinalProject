using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class PublicSchoolClassSchedule
    {
        [Key]
        public int PublicSchoolClassScheduleID { get; set; }

        [Display(Name = "StudentPublicSchoolClass")]
        [Required]
        public int StudentPublicSchoolClassID { get; set; }
        [ForeignKey("StudentPublicSchoolClassID")]
        public virtual StudentPublicSchoolClass StudentPublicSchoolClass { get; set; }

        [Display(Name = "Schedule")]
        [Required]
        public int ScheduleID { get; set; }
        [ForeignKey("ScheduleID")]
        public virtual Schedule Schedule { get; set; }
    }
}

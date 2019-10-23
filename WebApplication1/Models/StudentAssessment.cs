using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class StudentAssessment
    {

        [Required]
        public int PointsAwarded { get; set; }
        [StringLength(5000)]
        public string Comment { get; set; }

        [Display(Name = "Assessment")]
        [Required]
        public int AssessnentID { get; set; }
        [ForeignKey("AssessmentID")]
        public virtual Assessment Assessment { get; set; }

        [Display(Name = "Student")]
        [Required]
        public int StudentID { get; set; }
        [ForeignKey("StudentID")]
        public virtual Student Student { get; set; }
    }
    
}

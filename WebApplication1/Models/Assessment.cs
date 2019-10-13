using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Assessment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Assessment Name")]
        public string AssessmentName { get; set; }

        [Required]
        [Display(Name = "Total Possible Score")]
        public int TotalPossibleScore { get; set; }

        [Required]
        [Display(Name = "Class")]
        public int ClassId { get; set; }

        [ForeignKey("ClassId")]
        public virtual Class Class { get; set; }
    }
}

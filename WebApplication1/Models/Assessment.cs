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
        public int AssessmentId { get; set; }
        [StringLength(500)]
        [Required]
        public string Title { get; set; }
        [StringLength(50000)]
        public string Description { get; set; }
        [Required]
        public int PointsPossible { get; set; }

        [Display(Name = "Class")]
        [Required]
        public int ClassID { get; set; }
        [ForeignKey("ClassID")]
        public virtual Class Class { get; set; }
    }
}

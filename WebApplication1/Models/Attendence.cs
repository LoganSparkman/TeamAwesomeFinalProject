using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Attendence
    {
        [Required]
        [Display(Name = "Student")]
        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [Required]
        [Display(Name = "Term")]
        public int TermId { get; set; }

        [ForeignKey("TermId")]
        public virtual Term Term { get; set; }

        [Required]
        [Display(Name = "Attended")]
        public byte AttendedYN { get; set; }

        [Required]
        [Display(Name = "Day Recorded")]
        public DateTime DateRecorded { get; set; }

    }
}

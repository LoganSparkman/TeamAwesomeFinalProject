using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }//Content of the note
        [Required]
        public string Type { get; set; }//Applicant Interviewer, Teacher, etc. - Enum not needed as the user won't be able to edit this

        [Required]
        [Display(Name = "Student")]
        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
    }
}

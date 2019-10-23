using Microsoft.AspNetCore.Identity;
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
        public int NoteID { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        [Display(Name = "Student")]
        public int StudentID { get; set; }

        [ForeignKey("StudentID")]
        public virtual Student Student { get; set; }
        [Required]
        [Display(Name = "User")]
        public string UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual IdentityUser IdentityUser { get; set; }
        [Required]
        [Display(Name = "NoteType")]
        public int NoteTypeID { get; set; }

        [ForeignKey("NoteTypeID")]
        public virtual NoteType NoteType { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ClassInstructor
    {
        //FKs to Primary Key Below

        [Display(Name = "Class")]
        [Required]
        public int ClassID { get; set; }
        [ForeignKey("ClassID")]
        public virtual Class Class { get; set; }

        [Required]
        [Display(Name = "User")]
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual IdentityUser IdentityUser { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ApplicantRating
    {
        [Key]
        public int ApplicantRatingID { get; set; }
        [Required]
        public int ScoreAssigned { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [StringLength(1000)]
        public string Comment { get; set; }
        //FKs below
        [Display(Name = "Student")]
        [Required]
        public int StudentID { get; set; }
        [ForeignKey("StudentID")]
        public virtual StudentStatus StudentStatus { get; set; }

        [Required]
        [Display(Name = "User")]
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual IdentityUser IdentityUser { get; set; }

        [Required]
        [Display(Name = "RatingCriterium")]
        public int RatingCriteriumID { get; set; }
        [ForeignKey("RatingCriteriumID")]
        public virtual RatingCriterium RatingCriterium { get; set; }

        [Required]
        [Display(Name = "Term")]
        public int TermID { get; set; }
        [ForeignKey("TermID")]
        public virtual Term Term { get; set; }
    }
}

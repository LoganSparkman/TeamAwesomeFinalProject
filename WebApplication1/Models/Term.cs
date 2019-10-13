using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Term
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime TermStart  { get; set; }

        [Required]
        public DateTime TermEnd { get; set; }

        [Display(Name = "Term")]
        public string TermName { get; set; }
    }
}

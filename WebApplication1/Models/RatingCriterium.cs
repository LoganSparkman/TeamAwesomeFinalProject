using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class RatingCriterium
    {
        [Key]
        public int RatingCriteriumID { get; set; }
        [StringLength(1000)]
        [Required]
        public string Description { get; set; }
        [Required]
        public int MaxScore { get; set; }
    }
}

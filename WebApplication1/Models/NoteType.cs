using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class NoteType
    {
        [Key]
        public int NoteTypeID { get; set; }
        [Required]
        [Display(Name="Note Type Name")]
        [StringLength(50)]
        public string Name { get; set; }
    }
}

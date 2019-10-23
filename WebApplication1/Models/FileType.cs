using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class FileType
    {
        [Key]
        public int FileTypeID { get; set; }
        [Required]
        [Display(Name = "File Type Name")]
        [StringLength(50)]
        public string Name { get; set; }
    }
}

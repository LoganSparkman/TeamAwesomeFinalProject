using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class File
    {
        [Key]
        public int FileID { get; set; }
        [Required]
        [StringLength(100)]
        public string Path { get; set; } //Possible change to byte[] up to whoever uses it first
        [Display(Name = "Student")]
        [Required]
        public int StudentID { get; set; }

        [ForeignKey("StudentID")]
        public virtual Student Student { get; set; }
        [Display(Name = "FileType")]
        [Required]
        public int FileTypeID { get; set; }

        [ForeignKey("FileTypeID")]
        public virtual FileType FileType { get; set; }

    }
}

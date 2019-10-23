using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class AttendanceStatus
    {
        [Key]
        public int AttendanceStatusID { get; set; }
        [StringLength(250)]
        [Required]
        public string Name { get; set; }
    }
}

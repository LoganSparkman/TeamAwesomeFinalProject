using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Attendance
    {
        [Key]
        public int AttendaneID { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required]
        public DateTime TimeIn { get; set; }
        [Required]
        public DateTime TimeOut { get; set; }

        [Display(Name = "Student")]
        [Required]
        public int StudentID { get; set; }
        [ForeignKey("StudentID")]
        public virtual Student Student { get; set; }

        [Display(Name = "Class")]
        [Required]
        public int ClassID { get; set; }
        [ForeignKey("ClassID")]
        public virtual Class Class { get; set; }

        [Display(Name = "AttendanceStatus")]
        [Required]
        public int AttendanceStatusID { get; set; }
        [ForeignKey("AttendanceStatusID")]
        public virtual AttendanceStatus AttendanceStatus { get; set; }
    }
}

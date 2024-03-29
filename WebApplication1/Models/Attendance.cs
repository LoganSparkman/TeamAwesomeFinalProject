﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Attendance
    {
        
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public DateTime TimeIn { get; set; }

        [Display(Name = "Student")]
        [Required]
        public int StudentID { get; set; }
        [ForeignKey("StudentID")]
        public virtual Student Student { get; set; }

        [Display(Name = "Course")]
        [Required]
        public string CourseName { get; set; }

        [Display(Name = "AttendanceStatus")]
        [Required]
        public int AttendanceStatusID { get; set; }
        [ForeignKey("AttendanceStatusID")]
        public virtual AttendanceStatus AttendanceStatus { get; set; }
    }
}

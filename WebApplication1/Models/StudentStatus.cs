﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class StudentStatus
    {
        [Key]
        public int StudentStatusID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Student Status Name")]
        public string Name { get; set; }
    }
}

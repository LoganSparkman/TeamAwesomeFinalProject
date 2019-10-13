using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Applicant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string Fname { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string Lname { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Display(Name = "Public School Level")]
        public int SchoolLevel { get; set; }

        [Display(Name = "Guardian Name")]
        public string GuardianName { get; set; }

        [Display(Name = "Guardian Type")]
        public string GuardianType { get; set; }

        public string Address { get; set; }
        public string Village { get; set; }
        public string GPS { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }
        public string Status { get; set; }
    }
}

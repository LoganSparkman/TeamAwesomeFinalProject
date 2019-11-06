using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        [Display(Name = "First Name")]
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Display(Name = "Date of Birth")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        [Required]
        [StringLength(50)]
        public string Village { get; set; }
        [Required]
        [Display(Name = "GPS Latitude")]
        public decimal GPSLatitude { get; set; }
        [Required]
        [Display(Name = "GPS Longitude")]
        public decimal GPSLongitude { get; set; }
        [Required]
        [Display(Name ="Public School Level")]
        public Int16 PublicSchoolLevel { get; set; }
        [Required]
        [Display(Name ="Guardian Name")]
        [StringLength(100)]
        public string GuardianName { get; set; }
        [Required]
        [Display(Name ="Guardian Type")]
        [StringLength(50)]
        public string GuardianType { get; set; }
        [Display(Name ="Phone Number")]
        [StringLength(20)]
        public string Phone { get; set; }
        public byte[] Picture { get; set; }//Possible change to string path. Up to whoever uses it first
        [Display(Name = "StudentStatus")]
        [Required]
        public int StudentStatusID { get; set; }

        [ForeignKey("StudentStatusID")]
        public virtual StudentStatus StudentStatus { get; set; }


    }
}

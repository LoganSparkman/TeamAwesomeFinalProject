using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Student> Student { get; set; }
        public DbSet<FileType> FileType { get; set; }
        public DbSet<File> File { get; set; }
        public DbSet<StudentStatus> StudentStatus { get; set; }
        public DbSet<Note> Note { get; set; }
        public DbSet<NoteType> NoteType { get; set; }
        public DbSet<Term> Term { get; set; }
        public DbSet<RatingCriterium> RatingCriterium { get; set; }
        public DbSet<ApplicantRating> ApplicantRating { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<ClassInstructor> ClassInstructor { get; set; }
        public DbSet<StudentClass> StudentClass { get; set; }
        public DbSet<Assessment> Assessment { get; set; }
        public DbSet<StudentAssessment> StudentAssessment { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<AttendanceStatus> AttendanceStatus { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<ClassSchedule> ClassSchedule { get; set; }
        public DbSet<StudentPublicSchoolClass> StudentPublicSchoolClass { get; set; }
        public DbSet<PublicSchoolClassSchedule> PublicSchoolClassSchedule { get; set; }

        //Below is an attempt at creating tables using FKs as PKs. This should be possible, but it is nessesary to know
        //All of the classes in the Identity framework, and the DB tables. If this is known, then we can add FKPK tables.
        
            
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Call Base OnModelCreating
            base.OnModelCreating(modelBuilder);

            //Below is nessesary for composite Keys
            modelBuilder.Entity<ClassInstructor>()
                .HasKey(c => new { c.ClassID, c.UserID });
            modelBuilder.Entity<StudentClass>()
                .HasKey(c => new { c.ClassID, c.StudentID });
            modelBuilder.Entity<Attendance>()
                .HasKey(c => new { c.ClassID, c.StudentID, c.Date });
            modelBuilder.Entity<ClassSchedule>()
                .HasKey(c => new { c.ClassID, c.ScheduleID });
            modelBuilder.Entity<StudentAssessment>()
                .HasKey(c => new { c.StudentID, c.AssessnentID });
        }
        
    }
}

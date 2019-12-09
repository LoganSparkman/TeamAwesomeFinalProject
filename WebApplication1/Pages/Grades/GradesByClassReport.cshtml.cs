using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Pages.Grades
{
    public class GradesByClassReportModel : PageModel
    {
        public Course Course { get; set; }

        public IList<Class> Class { get; set; }

        public IList<Student> Students { get; set; }

        public string[] FirstNames;
        public string[] LastNames;
        public int[] StudentScores;

        public IList<StudentAssessment> Scores { get; set; }

        private readonly WebApplication1.Data.ApplicationDbContext _context;
        public GradesByClassReportModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public int classId { get; set; }

        public async Task OnGetAsync(int classId)
        {
            this.classId = classId;

            Class = await _context.Class
                 .Where(c => c.ClassID == classId)
                 .ToListAsync();



            for (int i = 0; i < Class.Count; i++)
            {
                Course = await _context.Course
                        .Where(c => c.CourseID == Class[i].CourseID)
                        .FirstOrDefaultAsync();
            }

            Students = await (from s in _context.Student
                              join d in _context.StudentClass
                              on s.StudentID equals d.StudentID
                              join f in _context.Class
                              on d.ClassID equals f.ClassID
                              where f.ClassID == classId
                              select s).ToListAsync();

            FirstNames = new string[Students.Count];
            LastNames = new string[Students.Count];
            int x = 0;
            foreach (Student s in Students)
            {
                FirstNames[x] = s.FirstName;
                LastNames[x] = s.LastName;
                x++;
            }


            Scores = await (from s in _context.Assessment
                              join d in _context.Class
                              on s.ClassID equals d.ClassID
                              join f in _context.StudentAssessment
                              on s.AssessmentId equals f.AssessmentID
                              where s.ClassID == classId
                              select f).ToListAsync();

            StudentScores = new int[Scores.Count];
            int y = 0;
            foreach (StudentAssessment s in Scores)
            {
                StudentScores[y] = s.PointsAwarded;
                y++;
            }

        }
    }
}
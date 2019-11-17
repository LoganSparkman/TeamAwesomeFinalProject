using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Utility;

namespace WebApplication1.Pages.Grades
{
    [Authorize(Roles = SD.InstructorUser)]
    public class GradesListModel : PageModel
    {
        private readonly WebApplication1.Data.ApplicationDbContext _context;

        public GradesListModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<StudentAssessment> StudentAssessment { get;set; }

        public async Task OnGetAsync(int studentId, int classId)
        {
            StudentAssessment = await _context.StudentAssessment
                .Include(s => s.Student)
                .Where(s =>s.StudentID == studentId)
                .Where(s => s.Assessment.ClassID == classId)
                .ToListAsync();
            IList<Assessment> assessments = await _context.Assessment
                .Where(c => c.ClassID == classId)
                .ToListAsync();
            int i = 0;
            //Add grades into database if not already there
            while(StudentAssessment.Count != assessments.Count)
            {
                StudentAssessment sa = await _context.StudentAssessment
                    .Where(s => s.StudentID == studentId)
                    .Where(a => a.AssessmentID == assessments[i].AssessmentId)
                    .FirstOrDefaultAsync();
                if (sa == null)
                {
                    sa = new StudentAssessment
                    {
                        AssessmentID = assessments[i].AssessmentId,
                        StudentID = studentId,
                        Comment = ""
                    };
                    _context.StudentAssessment.Add(sa);
                    await _context.SaveChangesAsync();
                }
                i++;
                StudentAssessment = await _context.StudentAssessment
                    .Include(s => s.Student)
                    .Where(s => s.StudentID == studentId)
                    .Where(s => s.Assessment.ClassID == classId)
                    .ToListAsync();
            }
        }
    }
}

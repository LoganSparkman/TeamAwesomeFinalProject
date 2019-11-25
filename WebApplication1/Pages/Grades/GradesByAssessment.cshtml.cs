using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Grades
{
    public class GradesByAssessmentModel : PageModel
    {
        private readonly WebApplication1.Data.ApplicationDbContext _context;

        public GradesByAssessmentModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<StudentAssessment> StudentAssessment { get;set; }

        public async Task<IActionResult> OnGetAsync(int? AssessmentId)
        {
            if (AssessmentId == null)
            {
                return NotFound();
            }
            Assessment thisAssessment = await _context.Assessment
                .Where(a => a.AssessmentId == AssessmentId)
                .FirstOrDefaultAsync();
            StudentAssessment = await _context.StudentAssessment
                .Include(s => s.Assessment)
                .Include(s => s.Student)
                .Where(a => a.AssessmentID == AssessmentId).ToListAsync();
            int i = 0;
            //Add grades into database if not already there
            List<StudentClass> Students = await _context.StudentClass
                .Where(c => c.ClassID == thisAssessment.ClassID)
                .ToListAsync();
            /*while (StudentAssessment.Count != assessments.Count)
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
            }*/
            return Page();
        }
        public async Task OnPostAsync()
        {
            List<StudentAssessment> FromDB = await _context.StudentAssessment
                .Include(s => s.Assessment)
                .Include(s => s.Student)
                .Where(a => a.AssessmentID == StudentAssessment[0].AssessmentID).ToListAsync();
            for (int i = 0; i < FromDB.Count; i++)
            {
                FromDB[i].StudentID = StudentAssessment[i].StudentID;
                FromDB[i].PointsAwarded = StudentAssessment[i].PointsAwarded;
                FromDB[i].AssessmentID = StudentAssessment[i].AssessmentID;
                FromDB[i].Comment = StudentAssessment[i].Comment;
            }
            await _context.SaveChangesAsync();
            await OnGetAsync(StudentAssessment[0].AssessmentID);
        }
    }
}

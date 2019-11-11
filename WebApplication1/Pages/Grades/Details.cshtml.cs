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
    public class DetailsModel : PageModel
    {
        private readonly WebApplication1.Data.ApplicationDbContext _context;

        public DetailsModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public StudentAssessment StudentAssessment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? StudentId, int? AssesmentId)
        {
            if (StudentId == null || AssesmentId == null)
            {
                return NotFound();
            }

            StudentAssessment = await _context.StudentAssessment
                .Include(s => s.Assessment)
                .Include(s => s.Student)
                .Where(s => s.AssessmentID == AssesmentId)
                .Where(s => s.StudentID == StudentId)
                .FirstOrDefaultAsync();

            if (StudentAssessment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Utility;

namespace WebApplication1.Pages.Grades
{
    [Authorize(Roles = SD.InstructorUser)]
    public class EditModel : PageModel
    {
        private readonly WebApplication1.Data.ApplicationDbContext _context;

        public EditModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["AssessmentID"] = new SelectList(_context.Assessment, "AssessmentId", "Title");
           ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "FirstName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(StudentAssessment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentAssessmentExists(StudentAssessment.StudentID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./ClassList");
        }

        private bool StudentAssessmentExists(int id)
        {
            return _context.StudentAssessment.Any(e => e.StudentID == id);
        }
    }
}

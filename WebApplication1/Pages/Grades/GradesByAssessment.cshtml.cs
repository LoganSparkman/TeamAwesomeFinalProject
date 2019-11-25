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
    public class GradesByAssessmentModel : PageModel
    {
        private readonly WebApplication1.Data.ApplicationDbContext _context;

        public GradesByAssessmentModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<StudentAssessment> StudentAssessment { get; set; }
        public async Task<IActionResult> OnGet(int AssessmentId)
        {
            Assessment thisAssessment = await _context.Assessment
                .Include(c => c.Class)
                .Where(a => a.AssessmentId == AssessmentId)
                .FirstOrDefaultAsync();


            return Page();
        }
    }
}
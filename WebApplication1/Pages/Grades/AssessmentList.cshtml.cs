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
    public class AssessmentListModel : PageModel
    {
        private readonly WebApplication1.Data.ApplicationDbContext _context;

        public AssessmentListModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Assessment> Assessment { get;set; }

        public async Task<IActionResult> OnGetAsync(int? ClassId)
        {
            if (ClassId == null)
            {
                return NotFound();
            }
            Assessment = await _context.Assessment
                .Include(a => a.Class)
                .Where(c => c.ClassID == ClassId).ToListAsync();
            return Page();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.PublicClasses
{
    public class EditModel : PageModel
    {
        private readonly WebApplication1.Data.ApplicationDbContext _context;

        public EditModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StudentPublicSchoolClass StudentPublicSchoolClass { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StudentPublicSchoolClass = await _context.StudentPublicSchoolClass
                .Include(s => s.Student).FirstOrDefaultAsync(m => m.StudentPublicSchoolClassID == id);

            if (StudentPublicSchoolClass == null)
            {
                return NotFound();
            }
           ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "FirstName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(StudentPublicSchoolClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentPublicSchoolClassExists(StudentPublicSchoolClass.StudentPublicSchoolClassID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StudentPublicSchoolClassExists(int id)
        {
            return _context.StudentPublicSchoolClass.Any(e => e.StudentPublicSchoolClassID == id);
        }
    }
}

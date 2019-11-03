using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Classes
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication1.Data.ApplicationDbContext _context;

        public DeleteModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Class Class { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Class = await _context.Class
                .Include(c => c.Course)
                .Include(t => t.Term).FirstOrDefaultAsync(m => m.ClassID == id);

            if (Class == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Class = await _context.Class.FindAsync(id);
            var ClassSchedules = _context.ClassSchedule.Where(c => c.ClassID == id);

            if (Class != null)
            {
                _context.Class.Remove(Class);
                _context.ClassSchedule.RemoveRange(ClassSchedules);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

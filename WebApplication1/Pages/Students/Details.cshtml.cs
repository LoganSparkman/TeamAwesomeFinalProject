using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication1.Data.ApplicationDbContext _context;

        public DetailsModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Student Student { get; set; }
        public IList<Note> Note { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Student
                .Include(s => s.StudentStatus).FirstOrDefaultAsync(m => m.StudentID == id);

            Note = await _context.Note
                .Include(n => n.NoteType)
                .Include(n => n.Student)
                .Where(n => n.StudentID == id).ToListAsync();


            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

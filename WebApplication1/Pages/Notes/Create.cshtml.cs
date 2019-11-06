using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Notes
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication1.Data.ApplicationDbContext _context;

        public CreateModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Name", User.FindFirstValue(ClaimTypes.NameIdentifier));
            ViewData["NoteTypeID"] = new SelectList(_context.NoteType, "NoteTypeID", "Name");
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "FirstName", id);
            Note = new Note
            {
                StudentID = id
            };
            return Page();
        }

        [BindProperty]
        public Note Note { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Note.Add(Note);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { id = Note.StudentID });
        }
    }
}
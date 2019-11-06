using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Assessments
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication1.Data.ApplicationDbContext _context;

        public CreateModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public string CourseName;

        public IActionResult OnGet(int id)
        {
            Assessment = new Assessment
            {
                ClassID = id
            };
            CourseName = _context.Class.Where(c => c.ClassID == id).Select(c => c.Course.Name).FirstOrDefault();
            return Page();
        }

        [BindProperty]
        public Assessment Assessment { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Assessment.Add(Assessment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { id = Assessment.ClassID });
        }
    }
}
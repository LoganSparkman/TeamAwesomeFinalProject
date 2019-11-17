using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.PublicClasses
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication1.Data.ApplicationDbContext _context;

        public DetailsModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}

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
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Data.ApplicationDbContext _context;

        public IndexModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<StudentPublicSchoolClass> StudentPublicSchoolClass { get;set; }

        public async Task OnGetAsync()
        {
            StudentPublicSchoolClass = await _context.StudentPublicSchoolClass
                .Include(s => s.Student).ToListAsync();
        }
    }
}

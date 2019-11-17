using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Assessments
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Data.ApplicationDbContext _context;

        public IndexModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Assessment> Assessment { get;set; }
        public int? classID;
        public string CourseName;

        public async Task OnGetAsync(int? id)
        {
            CourseName = _context.Class.Where(c => c.ClassID == id).Select(c => c.Course.Name).FirstOrDefault();
            classID = id;
            Assessment = await _context.Assessment
                .Include(a => a.Class)
                .Where(a => a.ClassID == id).ToListAsync();
        }
    }
}

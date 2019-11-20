using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Pages.Attendance
{
    public class RunClassReportModel : PageModel
    {
        public Course Course { get; set; }

        public IList<Class> Class { get; set; }

        private readonly WebApplication1.Data.ApplicationDbContext _context;
        public RunClassReportModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public int classId { get; set; }

        public async Task OnGetAsync(int classId)
        {
            this.classId = classId;

            Class =  await _context.Class
                    .Where(c => c.ClassID == classId)
                    .ToListAsync();

            for(int i = 0; i < Class.Count; i++)
            {
                Course = await _context.Course
                        .Where(c => c.CourseID == Class[i].CourseID)
                        .FirstOrDefaultAsync();
            }

        }
    }
}
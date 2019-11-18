using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Utility;

namespace WebApplication1.Pages.Attendance
{
    [Authorize(Roles = SD.InstructorUser)]
    public class ClassListModel : PageModel
    {
        private readonly WebApplication1.Data.ApplicationDbContext _context;

        public ClassListModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Class> Class { get; set; }

        public async Task OnGetAsync()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            string userId = claim.Value;

            Class = await _context.Class.Include(c => c.Course).Include(c => c.Term).Where(u => u.ClassID == -1).ToListAsync();
            IList<ClassInstructor> Classes = await _context.ClassInstructor
                .Include(c => c.Class)
                .Where(u => u.UserID == userId)
                .ToListAsync();
            //Class = new IList<Class>();
            for (int i = 0; i < Classes.Count; i++)
            {
                Class.Add(await _context.Class
                    .Include(c => c.Course)
                    .Include(c => c.Term)
                    .Where(c => c.ClassID == Classes[i].ClassID).FirstOrDefaultAsync());
            }
        }
    }
}
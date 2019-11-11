using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Utility;

namespace WebApplication1.Pages.Grades
{
    [Authorize(Roles = SD.InstructorUser)]
    public class StudentListModel : PageModel
    {
        private readonly WebApplication1.Data.ApplicationDbContext _context;

        public StudentListModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; }
        public int classId { get; set; }
        public async Task OnGetAsync(int classId)
        {
            this.classId = classId;
            Student = await _context.Student.Where(s => s.StudentID == -1).ToListAsync();
            IList<StudentClass> studentClasses = await _context.StudentClass.Where(c => c.ClassID == classId).ToListAsync();

            for (int i = 0; i < studentClasses.Count; i++)
            {
                Student.Add(await _context.Student
                    .Where(c => c.StudentID == studentClasses[i].StudentID).FirstOrDefaultAsync());
            }
        }
    }
}

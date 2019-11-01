using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApplication1.Pages.Students
{
    public class ChangeScheduleModel : PageModel
    {
        private readonly WebApplication1.Data.ApplicationDbContext _context;

        public ChangeScheduleModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IList<StudentClass> StudentClass { get; set; }
        [BindProperty]
        public IList<Class> Class { get; set; }
        [BindProperty]
        public Student Student { get; set; }

        public List<ClassSchedule> classSchedules = new List<ClassSchedule>();

        public async Task OnGetAsync(int? id)
        { 
            Class = await _context.Class
                .Include(c => c.Course)
                .Include(t => t.Term).ToListAsync();

            Student = await _context.Student
                .Include(s => s.StudentStatus).FirstOrDefaultAsync(m => m.StudentID == id);

            //classSchedules = await _context.Schedule.ToListAsync();
            List<int> ClassList = await _context.StudentClass.Where(s => s.StudentID == id).Select(s=>s.ClassID).ToListAsync();
            foreach(int i in ClassList)
            {
                List<ClassSchedule> schedule = await _context.ClassSchedule
                    .Include(c => c.Schedule)
                    .Include(c => c.Class)
                    .Where(c => c.ClassID == i).ToListAsync();
                classSchedules.AddRange(schedule);
            }

            StudentClass = await _context.StudentClass.ToListAsync();
        }

        public async Task<IActionResult> OnPostAdd(int id, int classID)
        {
            
            try
            {
                StudentClass StudentClass = new StudentClass();
                StudentClass.StudentID = id;
                StudentClass.ClassID = classID;
                _context.StudentClass.Add(StudentClass);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(Student.StudentID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./ChangeSchedule", new { id });
        }

        public async Task<IActionResult> OnPostRemove(int id, int classID)
        {
            var StudentClass = await _context.StudentClass.FindAsync(classID, id);

            _context.StudentClass.Remove(StudentClass);
            await _context.SaveChangesAsync();

            return RedirectToPage("./ChangeSchedule", new { id });
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.StudentID == id);
        }
    }
}
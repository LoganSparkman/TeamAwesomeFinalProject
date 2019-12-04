using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Pages.AdminTools
{
    public class PrintSchedulesModel : PageModel
    {
        public readonly ApplicationDbContext _context;

        public PrintSchedulesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Term Term { get; set; }

        public List<PrintStudentSchedules> StudentSchedules = new List<PrintStudentSchedules>();

        public void OnGet()
        {
            ViewData["TermID"] = new SelectList(_context.Term, "TermID", "Description");
        }

        public async Task OnPost(int termid)
        {
            IList<Student> StudentList = await _context.Student.Where(s => s.StudentStatusID == 2).ToListAsync();

            foreach (var student in StudentList)
            {
                List<int> ClassList = await _context.StudentClass
                .Where(s => s.StudentID == student.StudentID)
                .Where(s => s.Class.TermID == termid)
                .Select(s => s.ClassID).ToListAsync();

                //publicClassSchedules = await _context.PublicSchoolClassSchedule
                //    .Include(p => p.Schedule)
                //    .Include(p => p.StudentPublicSchoolClass)
                //    .Where(p => p.StudentPublicSchoolClass.StudentID == id).ToListAsync

                PrintStudentSchedules p = new PrintStudentSchedules();
                p.Student = student;
                p.Schedules = new List<ClassSchedule>();

                foreach (int i in ClassList)
                {
                    List<ClassSchedule> schedule = await _context.ClassSchedule
                        .Include(c => c.Schedule)
                        .Include(c => c.Class)
                        .Include(c => c.Class.Course)
                        .Where(c => c.ClassID == i).ToListAsync();
                    p.Schedules.AddRange(schedule);
                }
                if (p.Schedules.Count > 0)
                {
                    StudentSchedules.Add(p);
                }
            }
            ViewData["TermID"] = new SelectList(_context.Term, "TermID", "Description");
        }
    }
}
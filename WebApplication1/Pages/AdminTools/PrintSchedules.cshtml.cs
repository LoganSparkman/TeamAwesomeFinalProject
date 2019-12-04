using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public List<PrintStudentSchedules> StudentSchedules = new List<PrintStudentSchedules>();

        public async Task OnGetAsync()
        {
            IList<Student> StudentList = await _context.Student.Where(s => s.StudentStatusID == 2).ToListAsync();

            foreach (var student in StudentList)
            {
                List<int> ClassList = await _context.StudentClass
                .Where(s => s.StudentID == student.StudentID)
                .Where(s => s.Class.TermID == 1)
                .Select(s => s.ClassID).ToListAsync();

                //publicClassSchedules = await _context.PublicSchoolClassSchedule
                //    .Include(p => p.Schedule)
                //    .Include(p => p.StudentPublicSchoolClass)
                //    .Where(p => p.StudentPublicSchoolClass.StudentID == id).ToListAsync
                PrintStudentSchedules p = new PrintStudentSchedules();
                p.Student = student;
                StudentSchedules.Add(p);

                foreach (int i in ClassList)
                {
                    List<ClassSchedule> schedule = await _context.ClassSchedule
                        .Include(c => c.Schedule)
                        .Include(c => c.Class)
                        .Where(c => c.ClassID == i).ToListAsync();
                    p.Schedules.AddRange(schedule);
                }
            }
        }
    }
}
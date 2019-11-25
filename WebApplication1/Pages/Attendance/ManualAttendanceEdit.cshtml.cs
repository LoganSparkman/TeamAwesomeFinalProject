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
    public class ManualAttendanceEditModel : PageModel
    {
        public IList<Models.Attendance> Attendance { get; set; }

        public IList<Student> Student { get; set; }

        public IList<StudentClass> StudentClass { get; set; }

        public string Date { get; set; }

        private readonly WebApplication1.Data.ApplicationDbContext _context;
        public ManualAttendanceEditModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public int classId { get; set; }

        public void OnGet(int classId)
        {
            this.classId = classId;
        }

        public async Task OnPostGetAttendance(string date, int classid)
        {
            Date = date;

            DateTime d = Convert.ToDateTime(date);

            StudentClass = await _context.StudentClass
                           .Where(c => c.ClassID == classid)
                           .ToListAsync();

            Student = await _context.Student.Where(u => u.StudentID == -1).ToListAsync();
            for (int i = 0; i < StudentClass.Count; i++)
            {
                Student.Add(await _context.Student
                    .Where(s => s.StudentID == StudentClass[i].StudentID).FirstOrDefaultAsync());
            }

            Attendance = await _context.Attendance
                        .Where(c => c.ClassID == classid && c.Date == d)
                        .ToListAsync();

        }
    }
}
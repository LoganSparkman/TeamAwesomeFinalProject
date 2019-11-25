using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Pages.Students
{
    public class AttendanceAnalysisModel : PageModel
    {
        public int attended;
        public int late;
        public int absent;

        public Student Student { get; set; }

        public IList<Models.Attendance> Attendance { get; set; }

        private readonly WebApplication1.Data.ApplicationDbContext _context;
        public AttendanceAnalysisModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public int studentid { get; set; }

        public async Task OnGetAsync(int studentid)
        {
            this.studentid = studentid;

            Attendance = await _context.Attendance
                         .Where(s => s.StudentID == studentid)
                         .ToListAsync();

            Student = await _context.Student
                        .Where(s => s.StudentID == studentid)
                        .FirstOrDefaultAsync();

            foreach (var attendance in Attendance)
            {
                if (attendance.AttendanceStatusID == 1)
                {
                    attended++;
                }
                else if (attendance.AttendanceStatusID == 2)
                {
                    late++;
                }
                else
                {
                    absent++;
                }
            }
        }
    }
}
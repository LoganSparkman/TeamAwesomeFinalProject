using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Utility;

namespace WebApplication1.Pages.Attendance
{
    [Authorize(Roles = SD.InstructorUser)]

    public class EnterAttendanceModel : PageModel
    {
        private readonly WebApplication1.Data.ApplicationDbContext _context;
        public EnterAttendanceModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public int classId { get; set; }

        public void OnGet(int classId)
        {
            this.classId = classId;
        }
    }
}
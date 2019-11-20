using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Attendance
{
    public class RunClassReportModel : PageModel
    {
        private readonly WebApplication1.Data.ApplicationDbContext _context;
        public RunClassReportModel(WebApplication1.Data.ApplicationDbContext context)
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
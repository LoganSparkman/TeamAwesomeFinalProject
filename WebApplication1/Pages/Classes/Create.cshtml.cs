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

namespace WebApplication1.Pages.Classes
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication1.Data.ApplicationDbContext _context;

        [BindProperty]
        public IEnumerable<Term> Terms { get; set; }
        [BindProperty]
        public IEnumerable<Course> Courses { get; set; }
        [BindProperty]
        public IList<Schedule> Schedules { get; set; }
        [BindProperty]
        public IList<ScheduleHelper> Schedules2 { get; set; }

        public string FirstDay = "First Day";

        public string SecondDay = "Second Day";

        public CreateModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Schedules = _context.Schedule.ToList();
            Schedules2 = new List<ScheduleHelper>();

            foreach (Schedule Schedule in Schedules)
            {
                ScheduleHelper ScheduleHelp = new ScheduleHelper();
                ScheduleHelp.ScheduleID = Schedule.ScheduleID;
                ScheduleHelp.ListHelper = Schedule.DayOfWeek.ToString() + " " + Schedule.StartTime.ToString("hh:mm tt");
                Schedules2.Add(ScheduleHelp);
            }

            ViewData["CourseID"] = new SelectList(_context.Course, "CourseID", "Name");
            ViewData["TermID"] = new SelectList(_context.Term, "TermID", "TermID");
            ViewData["ScheduleID"] = new SelectList(Schedules2, "ScheduleID", "ListHelper");
            return Page();
        }

        [BindProperty]
        public Class Class { get; set; }
        [BindProperty]
        public ClassSchedule ScheduleFirstDay{ get; set; }
        [BindProperty]
        public ClassSchedule ScheduleSecondDay { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {

            _context.Class.Add(Class);
           
            await _context.SaveChangesAsync();

            //goes in and finds the last record in the table so we can use the id to create our two class schedule records
            int classID = _context.Class
                    .OrderByDescending(c => c.ClassID)
                    .Select(r => r.ClassID)
                    .First();

            ScheduleFirstDay.ClassID = classID;
            ScheduleSecondDay.ClassID = classID;
            _context.ClassSchedule.Add(ScheduleFirstDay);
            _context.ClassSchedule.Add(ScheduleSecondDay);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }

    public class ScheduleHelper
    {
        public int ScheduleID { get; set; }
        public string ListHelper { get; set; }
    }
}
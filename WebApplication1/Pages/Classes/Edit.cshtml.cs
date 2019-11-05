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
    public class EditModel : PageModel
    {
        private readonly WebApplication1.Data.ApplicationDbContext _context;

        [BindProperty]
        public IList<Schedule> Schedules { get; set; }
        [BindProperty]
        public IList<ScheduleHelper> Schedules2 { get; set; }

        public string FirstDay = "First Day";

        public string SecondDay = "Second Day";

        public EditModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Class Class { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Schedules = _context.Schedule.ToList();
            Schedules2 = new List<ScheduleHelper>();

            foreach (Schedule Schedule in Schedules)
            {
                ScheduleHelper ScheduleHelp = new ScheduleHelper();
                ScheduleHelp.ScheduleID = Schedule.ScheduleID;
                ScheduleHelp.ListHelper = Schedule.DayOfWeek.ToString() + " " + Schedule.StartTime.ToString("hh:mm tt");
                Schedules2.Add(ScheduleHelp);
            }

            Class = await _context.Class
                .Include(c => c.Course)
                .Include(t => t.Term).FirstOrDefaultAsync(m => m.ClassID == id);

            if (Class == null)
            {
                return NotFound();
            }
            ViewData["CourseID"] = new SelectList(_context.Course, "CourseID", "Name");
            ViewData["TermID"] = new SelectList(_context.Term, "TermID", "TermID");
            ViewData["ScheduleID"] = new SelectList(Schedules2, "ScheduleID", "ListHelper");
            return Page();
        }


        [BindProperty]
        public ClassSchedule ScheduleFirstDay { get; set; }
        [BindProperty]
        public ClassSchedule ScheduleSecondDay { get; set; }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Class).State = EntityState.Modified; 

            var ClassSchedules = _context.ClassSchedule.Where(c => c.ClassID == id);

            _context.ClassSchedule.RemoveRange(ClassSchedules);
            await _context.SaveChangesAsync();

            try
            {
                ScheduleFirstDay.ClassID = id;
                ScheduleSecondDay.ClassID = id;
                _context.ClassSchedule.Add(ScheduleFirstDay);
                _context.ClassSchedule.Add(ScheduleSecondDay);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassExists(Class.ClassID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ClassExists(int id)
        {
            return _context.Class.Any(e => e.ClassID == id);
        }
    }
}

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

        public IList<ClassSchedule> ClassSchedule { get; set; }

        public IList<Schedule> Schedule { get; set; }

        public IList<Schedule> Schedule2 { get; set; }

        public IList<Class> Class { get; set; }

        public Course Course { get; set; }

        public string ThisDate { get; set; }

        public DateTime DayOne { get; set; }

        public DateTime DayTwo { get; set; }


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
            ThisDate = date;

            DateTime Date = Convert.ToDateTime(date);

            DateTime firstDay = Date.FirstDayOfWeek();
            DateTime lastDay = Date.LastDayOfWeek();

            Class = await _context.Class.Where(c => c.ClassID == classid).ToListAsync();

            for(int i = 0; i < Class.Count; i++)
            {
                Course = await _context.Course.Where(c => c.CourseID == Class[i].CourseID).FirstOrDefaultAsync();
            }

            Schedule = await _context.Schedule.ToListAsync();

            ClassSchedule = await _context.ClassSchedule.Where(c => c.ClassID == classid).ToListAsync();

            StudentClass = await _context.StudentClass
                           .Where(c => c.ClassID == classid)
                           .ToListAsync();


            Student = await _context.Student.Where(u => u.StudentID == -1).ToListAsync();

            for (int i = 0; i < StudentClass.Count; i++)
            {
                Student.Add(await _context.Student
                    .Where(s => s.StudentID == StudentClass[i].StudentID).FirstOrDefaultAsync());
            }

            //get all attendances in our date range
            Attendance = await _context.Attendance
                       .Where(c => c.Date >= firstDay).Where(c => c.Date <= lastDay).Where(c => c.CourseName == Course.Name)
                       .ToListAsync();

            int count = 0;

            foreach (var attend in Attendance)
            {
               
                if (count == 0)
                {
                    DayOne = attend.Date;
                }
                else if(attend.Date != DayOne)
                {
                    DayTwo = attend.Date;
                }
                count++;
            }
        }

    }

    public static partial class DateTimeExtensions
    {
        public static DateTime FirstDayOfWeek(this DateTime dt)
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var diff = dt.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;

            if (diff < 0)
            {
                diff += 7;
            }

            return dt.AddDays(-diff).Date;
        }

        public static DateTime LastDayOfWeek(this DateTime dt) =>
            dt.FirstDayOfWeek().AddDays(6);

        public static DateTime FirstDayOfMonth(this DateTime dt) =>
            new DateTime(dt.Year, dt.Month, 1);

        public static DateTime LastDayOfMonth(this DateTime dt) =>
            dt.FirstDayOfMonth().AddMonths(1).AddDays(-1);

        public static DateTime FirstDayOfNextMonth(this DateTime dt) =>
            dt.FirstDayOfMonth().AddMonths(1);
    }

}
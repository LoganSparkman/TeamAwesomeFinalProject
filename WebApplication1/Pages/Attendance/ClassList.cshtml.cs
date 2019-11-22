using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Utility;
using System.IO;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;

namespace WebApplication1.Pages.Attendance
{
    [Authorize(Roles = SD.InstructorUser)]
    public class ClassListModel : PageModel
    {
        private readonly WebApplication1.Data.ApplicationDbContext _context;

        public ClassListModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Class> Class { get; set; }
        public IList<Models.Attendance> LastEnteredAttendance { get; set; }

        public IList<Models.Attendance> Attendance { get; set; }

        public async Task OnGetAsync()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            string userId = claim.Value;

            Class = await _context.Class.Include(c => c.Course).Include(c => c.Term).Where(u => u.ClassID == -1).ToListAsync();
            IList<ClassInstructor> Classes = await _context.ClassInstructor
                .Include(c => c.Class)
                .Where(u => u.UserID == userId)
                .ToListAsync();
            //Class = new IList<Class>();
            for (int i = 0; i < Classes.Count; i++)
            {
                Class.Add(await _context.Class
                    .Include(c => c.Course)
                    .Include(c => c.Term)
                    .Where(c => c.ClassID == Classes[i].ClassID).FirstOrDefaultAsync());
            }

            //get the last entered attendance for classes
            LastEnteredAttendance = await _context.Attendance
                    .OrderByDescending(d => d.Date)
                    .GroupBy(c => c.ClassID)
                    .Select(c => c.First())
                    .ToListAsync();
        }

        public async Task<IActionResult> OnPostImport(IFormFile postedFile)
        {
            if (postedFile != null)
            {
                using (ExcelPackage package = new ExcelPackage(postedFile.OpenReadStream()))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    int colCount = worksheet.Dimension.End.Column;  //get Column Count
                    int rowCount = worksheet.Dimension.End.Row;     //get row count

                    for (int row = 1; row <= rowCount; row++)
                    {
                        int ClassID = 0;
                        int StudentID = 0;
                        DateTime Date = new DateTime();
                        DateTime TimeIn = new DateTime();
                        DateTime TimeOut = new DateTime();
                        int AttendanceStatusID = 1;
                        Models.Attendance tempAttendance = new Models.Attendance();

                        for (int col = 1; col <= colCount; col++)
                        {
                            //string currentThing = " Row:" + row + " column:" + col + " Value:" + worksheet.Cells[row, col].Value?.ToString().Trim();

                            if(col == 1)
                            {
                                ClassID = Int32.Parse(worksheet.Cells[row, col].Value?.ToString().Trim());
                            }
                            else if (col == 2)
                            {
                                StudentID = Int32.Parse(worksheet.Cells[row, col].Value?.ToString().Trim());
                            }
                            else if (col == 3)
                            {
                                Date = DateTime.Parse(worksheet.Cells[row, col].Value?.ToString().Trim());
                            }
                            else if (col == 4)
                            {
                                string tempDate = worksheet.Cells[row, col].Value?.ToString().Trim();
                                double date = double.Parse(tempDate);
                                TimeIn = DateTime.FromOADate(date);
                            }
                            else if (col == 5)
                            {
                                string tempDate = worksheet.Cells[row, col].Value?.ToString().Trim();
                                double date = double.Parse(tempDate);
                                TimeOut = DateTime.FromOADate(date);
                            }
                            else if (col == 6)
                            {
                                AttendanceStatusID = Int32.Parse(worksheet.Cells[row, col].Value?.ToString().Trim());
                            }

                        }
                        tempAttendance.ClassID = ClassID;
                        tempAttendance.StudentID = StudentID;
                        tempAttendance.Date = Date;
                        tempAttendance.TimeIn = TimeIn;
                        tempAttendance.TimeOut = TimeOut;
                        tempAttendance.AttendanceStatusID = AttendanceStatusID;

                        try
                        {
                            _context.Attendance.Add(tempAttendance);
                            await _context.SaveChangesAsync();
                        }
                        catch (DbUpdateException)
                        {
                            TempData["Message"] = "Error";
                        }

                        string test = ClassID.ToString() + " " + StudentID.ToString();
                    }
                }
            }
            return RedirectToPage("./ClassList");
        }
    }
}
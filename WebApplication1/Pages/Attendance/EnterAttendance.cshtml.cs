using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Utility;
using System.IO;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;

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

        public IActionResult OnPostImport(IFormFile postedFile)
        {
            using (ExcelPackage package = new ExcelPackage(postedFile.OpenReadStream()))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int colCount = worksheet.Dimension.End.Column;  //get Column Count
                int rowCount = worksheet.Dimension.End.Row;     //get row count

                for (int row = 1; row <= rowCount; row++)
                {
                    for (int col = 1; col <= colCount; col++)
                    {
                        string currentThing = " Row:" + row + " column:" + col + " Value:" + worksheet.Cells[row, col].Value?.ToString().Trim();
                    }
                }
            }

            return RedirectToPage("./ClassList");
        }
    }
}
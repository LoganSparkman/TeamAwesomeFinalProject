using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Pages.Assessments
{
    public class RunAssessmentReportModel : PageModel
    {
        public Course Course { get; set; }
        public Assessment Assessment { get; set; }
        public Student Student { get; set; }

        public int pointsAwarded;
        public int pointsPossible;

        public string studentFirstName;
        public string studentLastName;
        public string assessmentName;


        public IList<Class> ClassList { get; set; }
        public IList<Assessment> AssessmentList { get; set; }
        public IList<Student> StudentList { get; set; }

        public IList<Models.Attendance> Attendance { get; set; }

        private readonly WebApplication1.Data.ApplicationDbContext _context;
        public RunAssessmentReportModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public int classId { get; set; }
        public int assessmentId { get; set; }

        public async Task OnGetAsync(int assessmentId)
        {
            this.assessmentId = assessmentId;

            AssessmentList = await _context.Assessment
                    .Where(a => a.AssessmentId == assessmentId)
                    .ToListAsync();


            for (int i = 0; i < AssessmentList.Count; i++)
            {
                Assessment = await _context.Assessment
                        .Where(a => a.AssessmentId == AssessmentList[i].AssessmentId)
                        .FirstOrDefaultAsync();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Grades
{
    public class GraphModel : PageModel
    {
        private readonly WebApplication1.Data.ApplicationDbContext _context;

        public GraphModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<StudentAssessment> StudentAssessment { get; set; }
        public int _LessThan60Count { get; set; }
        public int _60_70Count { get; set; }
        public int _70_80Count { get; set; }
        public int _80_90Count { get; set; }
        public int _90_100Count { get; set; }

        public async Task OnGetAsync()
        {
            StudentAssessment = await _context.StudentAssessment
                .Include(s => s.Assessment)
                .Include(s => s.Student).ToListAsync();

            _LessThan60Count = 0;
            _60_70Count = 0;
            _70_80Count = 0;
            _80_90Count = 0;
            _90_100Count = 0;
            foreach (StudentAssessment item in StudentAssessment)
            {
                double a = (double)item.PointsAwarded;
                double b = (double)item.Assessment.PointsPossible;
                double c = a / b;
                if (c < 0.6)
                {
                    _LessThan60Count++;
                }
                else if (c < 0.7)
                {
                    _60_70Count++;
                }
                else if (c < 0.8)
                {
                    _70_80Count++;
                }
                else if (c < 0.9)
                {
                    _80_90Count++;
                }
                else
                {
                    _90_100Count++;
                }
            }
        }
    }
}

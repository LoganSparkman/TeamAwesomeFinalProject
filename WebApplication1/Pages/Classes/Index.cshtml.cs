using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Classes
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Data.ApplicationDbContext _context;

        public IndexModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public string ClassNameSort { get; set; }
        public string TermSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Class> Class { get;set; }

        public async Task OnGetAsync(string sortOrder,
        string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            ClassNameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            TermSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Class> classIQ = from c in _context.Class.Include(c => c.Course).Include(c => c.Term)
                                            select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                classIQ = classIQ.Where(c => c.Course.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    classIQ = classIQ.OrderByDescending(c => c.Course.Name);
                    break;
                default:
                    classIQ = classIQ.OrderBy(c => c.Course.Name);
                    break;
            }

            int pageSize = 5;
            Class = await PaginatedList<Class>.CreateAsync(
                classIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}

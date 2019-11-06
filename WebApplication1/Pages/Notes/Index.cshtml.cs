using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Notes
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Data.ApplicationDbContext _context;

        public IndexModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Note> Note { get;set; }
        public int? studentID;

        public async Task OnGetAsync(int? id)
        {
            if (id != null)
            {
                studentID = id;
                Note = await _context.Note
                    .Include(n => n.IdentityUser)
                    .Include(n => n.NoteType)
                    .Include(n => n.Student)
                    .Where(n => n.StudentID == id).ToListAsync();
            }
            else
            {
                Note = await _context.Note
                    .Include(n => n.IdentityUser)
                    .Include(n => n.NoteType)
                    .Include(n => n.Student).ToListAsync();
            }
        }
    }
}

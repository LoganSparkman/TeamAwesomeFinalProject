using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Classes
{
    public class CreatePublicSchoolClassModel : PageModel
    {
        private readonly WebApplication1.Data.ApplicationDbContext _context;

        public CreatePublicSchoolClassModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {

        }
    }
}
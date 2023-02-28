using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MindyCityFutbol.Data;

namespace MindyCityFutbol.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly MindyCityFutbol.Data.MindyCityFutbolContext _context;

        public DetailsModel(MindyCityFutbol.Data.MindyCityFutbolContext context)
        {
            _context = context;
        }

        public Team Team { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Team = await _context.Team.FirstOrDefaultAsync(m => m.Id == id);

            if (Team == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

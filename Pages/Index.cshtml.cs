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
    public class IndexModel : PageModel
    {
        private readonly MindyCityFutbol.Data.MindyCityFutbolContext _context;

        public IndexModel(MindyCityFutbol.Data.MindyCityFutbolContext context)
        {
            _context = context;
        }

        public IList<Team> Team { get;set; }

        public async Task OnGetAsync()
        {
            Team = await _context.Team.ToListAsync();
        }
    }
}

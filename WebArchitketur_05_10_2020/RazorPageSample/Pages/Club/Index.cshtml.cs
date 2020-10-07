using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageSample.Data;
using RazorPageSample.Models;

namespace RazorPageSample.Pages.Club
{
    public class IndexModel : PageModel
    {
        private readonly RazorPageSample.Data.ClubDBContext _context;

        public IndexModel(RazorPageSample.Data.ClubDBContext context)
        {
            _context = context;
        }

        public IList<Clubs> Clubs { get;set; }

        public async Task OnGetAsync()
        {
            Clubs = await _context.Clubs.ToListAsync();
        }
    }
}

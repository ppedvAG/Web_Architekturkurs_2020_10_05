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
    public class DeleteModel : PageModel
    {
        private readonly RazorPageSample.Data.ClubDBContext _context;

        public DeleteModel(RazorPageSample.Data.ClubDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Clubs Clubs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Clubs = await _context.Clubs.FirstOrDefaultAsync(m => m.Id == id);

            if (Clubs == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Clubs = await _context.Clubs.FindAsync(id);

            if (Clubs != null)
            {
                _context.Clubs.Remove(Clubs);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

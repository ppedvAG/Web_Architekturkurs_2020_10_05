using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using RazorPageSample.Data;
using RazorPageSample.Models;

namespace RazorPageSample.Pages.Club
{
    public class CreateModel : PageModel
    {
        private readonly RazorPageSample.Data.ClubDBContext _context;

        private string Vornamen;
        private string Nachname;

        private DateTime Geburtstag;

        public CreateModel(RazorPageSample.Data.ClubDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Clubs Clubs { get; set; } 

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Clubs.Add(Clubs);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

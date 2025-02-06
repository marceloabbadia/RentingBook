using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RentBook.Data;
using RentBook.Data.Entities;

namespace RentBook.Pages.AboutRenting
{
    public class DeleteModel : PageModel
    {
        private readonly RentBook.Data.RentingBooksDB _context;

        public DeleteModel(RentBook.Data.RentingBooksDB context)
        {
            _context = context;
        }

        [BindProperty]
        public Renting Renting { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renting = await _context.Rentings.FirstOrDefaultAsync(m => m.Id == id);

            if (renting is not null)
            {
                Renting = renting;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renting = await _context.Rentings.FindAsync(id);
            if (renting != null)
            {
                Renting = renting;
                _context.Rentings.Remove(Renting);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

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
    public class DetailsModel : PageModel
    {
        private readonly RentBook.Data.RentingBooksDB _context;

        public DetailsModel(RentBook.Data.RentingBooksDB context)
        {
            _context = context;
        }

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
    }
}

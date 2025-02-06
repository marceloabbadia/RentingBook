using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentBook.Data;
using RentBook.Data.Entities;

namespace RentBook.Pages.AboutRenting
{
    public class EditModel : PageModel
    {
        private readonly RentBook.Data.RentingBooksDB _context;

        public EditModel(RentBook.Data.RentingBooksDB context)
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

            var renting =  await _context.Rentings.FirstOrDefaultAsync(m => m.Id == id);
            if (renting == null)
            {
                return NotFound();
            }
            Renting = renting;
           ViewData["BookId"] = new SelectList(_context.Books, "Id", "Publisher");
           ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Renting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentingExists(Renting.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RentingExists(int id)
        {
            return _context.Rentings.Any(e => e.Id == id);
        }
    }
}

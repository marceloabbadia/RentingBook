using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentBook.Data;
using RentBook.Data.Entities;

namespace RentBook.Pages.AboutRenting
{
    public class CreateModel : PageModel
    {
        private readonly RentBook.Data.RentingBooksDB _context;

        public CreateModel(RentBook.Data.RentingBooksDB context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BookId"] = new SelectList(_context.Books, "Id", "Publisher");
        ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Renting Renting { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Rentings.Add(Renting);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

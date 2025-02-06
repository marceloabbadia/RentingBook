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
    public class IndexModel : PageModel
    {
        private readonly RentBook.Data.RentingBooksDB _context;

        public IndexModel(RentBook.Data.RentingBooksDB context)
        {
            _context = context;
        }

        public IList<Renting> Renting { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Renting = await _context.Rentings
                .Include(r => r.Book)
                .Include(r => r.User).ToListAsync();
        }
    }
}

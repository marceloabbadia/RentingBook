using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RentBook.Data
{
    public class RentingBooksDB : IdentityDbContext
    {
        public RentingBooksDB(DbContextOptions<RentingBooksDB> options)
            : base(options)
        {

        }
    }
}

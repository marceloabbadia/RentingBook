using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentBook.Data.Entities;

namespace RentBook.Data
{
    public class RentingBooksDB : IdentityDbContext
    {
        public RentingBooksDB(DbContextOptions<RentingBooksDB> options)
            : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Renting> Rentings { get; set; }
    }
}

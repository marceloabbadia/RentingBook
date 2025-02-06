using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RentBook.Data.Entities
{
    public class Renting
    {
        public int Id { get; set; }

        [Required]
        public DateTime RentedAt { get; set; }
        public DateTime? ReturnedAt { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public string UserId { get; set; }

        public Book Book { get; set; }
        public IdentityUser User { get; set; }
    }
}

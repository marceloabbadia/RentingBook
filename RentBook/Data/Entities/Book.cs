using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RentBook.Data.Entities
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        [Required]
        [StringLength(255)]
        public string Publisher { get; set; }

        // The following 2 properties are added to configure the FK to User
        public string UserId { get; set; }

        public IdentityUser User { get; set; }


        [Required] 
        public int AuthorId { get; set; } 

        public Author Author { get; set; } 


    }
}

using System.ComponentModel.DataAnnotations;

namespace RentBook.Data.Entities
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateOnly BirthDate { get; set; }

    }
}

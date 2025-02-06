namespace RentBook.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Publisher { get; set; }
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public int AuthorId { get; set; }
        public AuthorModel Author { get; set; }


    }
}

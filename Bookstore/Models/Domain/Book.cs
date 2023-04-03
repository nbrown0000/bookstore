namespace Bookstore.Models.Domain
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid ReservedBy { get; set; }
    }
}

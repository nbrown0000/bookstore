using Bookstore.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Data
{
    public class BookstoreDBContext : DbContext
    {
        public BookstoreDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}

using Bookstore.Models.Domain;

namespace Bookstore.Data
{
    public static class DBInitializer
    {
        public static void Initialize(BookstoreDBContext context)
        {
            if (context.Books.Any())
            {
                return;
            }

            var books = new List<Book>()
            {
                new Book()
                {
                    Id = Guid.Parse("9b0896fa-3880-4c2e-bfd6-925c87f22878"),
                    Title = "CQRS for Dummies"
                },
                new Book()
                {
                    Id = Guid.Parse("0550818d-36ad-4a8d-9c3a-a715bf15de76"),
                    Title = "Visual Studio Tips"
                },
                new Book()
                {
                    Id = Guid.Parse("8e0f11f1-be5c-4dbc-8012-c19ce8cbe8e1"),
                    Title = "NHibernate Cookbook"
                }
            };

            context.Books.AddRange(books);
            context.SaveChanges();
        }
    }
}

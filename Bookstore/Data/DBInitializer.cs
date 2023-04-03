using Bookstore.Models.Domain;

namespace Bookstore.Data
{
    public static class DBInitializer
    {
        public static void Initialize(BookstoreDBContext context)
        {
            SeedUsers(context);
            SeedBooks(context);
        }

        public static void SeedUsers(BookstoreDBContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var users = new List<User>()
            {
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "John Smith",
                    UserName = "Johnny5", 
                    Email = "john@gmail.com",
                    Password = "johnsmith5"
                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }

        public static void SeedBooks(BookstoreDBContext context)
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
                    Title = "CQRS for Dummies",
                    ReservedBy = Guid.Empty
                },
                new Book()
                {
                    Id = Guid.Parse("0550818d-36ad-4a8d-9c3a-a715bf15de76"),
                    Title = "Visual Studio Tips",
                    ReservedBy = Guid.Empty
                },
                new Book()
                {
                    Id = Guid.Parse("8e0f11f1-be5c-4dbc-8012-c19ce8cbe8e1"),
                    Title = "NHibernate Cookbook",
                    ReservedBy = Guid.Empty
                }
            };

            context.Books.AddRange(books);
            context.SaveChanges();
        }
    }
}

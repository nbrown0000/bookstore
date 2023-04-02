using Bookstore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookstoreDBContext context;

        public BooksController(BookstoreDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books = await context.Books.ToListAsync();

            return View(books);
        }
    }
}

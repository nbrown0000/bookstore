using Bookstore.Data;
using Bookstore.Models;
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
        public async Task<IActionResult> Index(string searchString)
        {

            if (!String.IsNullOrEmpty(searchString))
            {
                var books = await context.Books.Where(b => b.Title.Contains(searchString)).ToListAsync();
                return View(books);
            }

            var booksList = await context.Books.ToListAsync();
            return View(booksList);
        }
    }
}

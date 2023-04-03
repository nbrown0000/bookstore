using Bookstore.Data;
using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookstoreDBContext context;
        private readonly ILogger<BooksController> _logger;

        public BooksController(BookstoreDBContext context, ILogger<BooksController> logger)
        {
            this.context = context;
            _logger = logger;
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

        [Route("Reserve/{id:Guid}")]
        public async Task<IActionResult> Reserve(Guid id)
        {
            var userId = HttpContext.Session.GetString("UserId");

            if (String.IsNullOrEmpty(userId)) {
                var errorMessage = "User Id in session is null";
                _logger.LogError(errorMessage);
                HttpContext.Session.SetString("ErrorMessage", errorMessage);

                //return View("Index");
                return RedirectToRoute("UserLogin");
            }

            var book = context.Books.Where(b => b.Id == id).FirstOrDefault();

            if (book.ReservedBy != Guid.Empty)
            {
                var errorMessage = "Book already reserved, cannot reserve again";
                _logger.LogError(errorMessage);
                HttpContext.Session.SetString("ErrorMessage", errorMessage);

                //return View("Index");
            }

            book.ReservedBy = Guid.Parse(userId);
            context.SaveChanges();

            var booksList = await context.Books.ToListAsync();

            return View("Index", booksList);
        }
    }
}

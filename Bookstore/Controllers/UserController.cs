using Bookstore.Data;
using Bookstore.Models;
using Bookstore.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Controllers
{
    public class UserController : Controller
    {
        private readonly BookstoreDBContext context;
        private readonly ILogger<UserController> _logger;

        public UserController(BookstoreDBContext context, ILogger<UserController> logger)
        {
            this.context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            if (loginUser.Email == null || loginUser.Password == null)
            {
                return View("Error");
            }

            var data = context.Users.Where(u => u.Email == loginUser.Email && u.Password == loginUser.Password).ToList();
            if (data.Count() > 0)
            {
                // add session
                HttpContext.Session.SetString("UserId", data.FirstOrDefault().Id.ToString());
                HttpContext.Session.SetString("UserName", data.FirstOrDefault().Name);
                return RedirectToRoute("BooksRoute");
            }
            return RedirectToRoute("BooksRoute");
        }

        // TODO: Route for Register
    }
}

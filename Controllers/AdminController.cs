using Microsoft.AspNetCore.Mvc;
using GestionAbscence.Models;
using GestionAbscence.Data;
using System.Linq;

namespace GestionAbscence.Controllers
{
    public class AdminController : Controller
    {
        private readonly MyContextApp _context;

        public AdminController(MyContextApp context)
        {
            _context = context;
        }

        // Action to show the Index page (GET)
        public IActionResult Index()
        {
            return View();  // This will render the "Views/Admin/Index.cshtml"
        }

        //// Login action to validate user credentials and redirect to Admin page
        //[HttpPost]
        ////public IActionResult Login(string email, string password)
        ////{
        ////    // Validate login credentials (You can use your authentication logic here)
        ////    var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        ////    if (user != null)
        ////    {
        ////        // If the credentials are valid, redirect to the Admin page
        ////        return RedirectToAction("Index");
        ////    }
        ////    else
        ////    {
        ////        // If the credentials are invalid, show an error message
        ////        ModelState.AddModelError("", "Invalid login attempt.");
        ////        return View();  // You can return to the login page with an error message
        ////    }
        }
    }
}

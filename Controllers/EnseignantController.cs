using Microsoft.AspNetCore.Mvc;

namespace GestionAbscence.Controllers
{
    public class EnseignantController : Controller
    {
        // Action qui affiche la vue "Index.cshtml"
        public IActionResult Index()
        {
            return View();  // Cela rendra la vue "Views/Enseignant/Index.cshtml"
        }
    }
}

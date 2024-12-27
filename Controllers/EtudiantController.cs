using Microsoft.AspNetCore.Mvc;

namespace GestionAbscence.Controllers
{
    public class EtudiantController : Controller
    {
        // Action qui affiche la vue "Index.cshtml"
        public IActionResult Index()
        {
            return View();  // Cela rendra la vue "Views/Etudiant/Index.cshtml"
        }
    }
}

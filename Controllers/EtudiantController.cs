using Microsoft.AspNetCore.Mvc;
using GestionAbscence.Models;
using System.Collections.Generic;

namespace GestionAbscence.Controllers
{
    public class EtudiantController : Controller
    {
        public IActionResult Index()
        {
            // Simulez une liste d'étudiants pour la démonstration
            var etudiants = new List<EtudiantViewModel>
            {
                new EtudiantViewModel { Id = 1, Nom = "Doe", Prenom = "John", Email = "john.doe@example.com" },
                new EtudiantViewModel { Id = 2, Nom = "Smith", Prenom = "Anna", Email = "anna.smith@example.com" }
            };

            return View(etudiants);
        }
    }

    // Modèle pour représenter un étudiant
    public class EtudiantViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
    }
}

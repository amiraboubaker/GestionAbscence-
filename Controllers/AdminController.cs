using Microsoft.AspNetCore.Mvc;
using GestionAbscence.Models; // Assurez-vous que les modèles sont dans un namespace approprié.
using System.Collections.Generic;

namespace GestionAbscence.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            // Créer un modèle de vue avec des données simulées
            var model = new AdminDashboardViewModel
            {
                TotalEtudiants = 150,
                TotalMatieres = 12,
                AbsencesAujourdHui = 5,
                Absences = new List<AbsenceViewModel>
                {
                    new AbsenceViewModel
                    {
                        IdEtudiant = 1,
                        Nom = "Doe John",
                        Matiere = "Mathématiques",
                        Date = "2024-12-25"
                    },
                    new AbsenceViewModel
                    {
                        IdEtudiant = 2,
                        Nom = "Smith Jane",
                        Matiere = "Physique",
                        Date = "2024-12-25"
                    }
                }
            };

            return View(model);
        }
    }

    // Modèle pour la vue du tableau de bord
    public class AdminDashboardViewModel
    {
        public int TotalEtudiants { get; set; }
        public int TotalMatieres { get; set; }
        public int AbsencesAujourdHui { get; set; }
        public List<AbsenceViewModel> Absences { get; set; }
    }

    // Modèle pour représenter une absence
    public class AbsenceViewModel
    {
        public int IdEtudiant { get; set; }
        public string Nom { get; set; }
        public string Matiere { get; set; }
        public string Date { get; set; }
    }
}

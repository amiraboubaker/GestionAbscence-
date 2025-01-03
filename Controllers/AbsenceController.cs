using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using GestionAbscence.Models;
using System.Linq;
using GestionAbscence.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionAbscence.Controllers
{
    public class AbsenceController : Controller
    {
        private readonly MyContextApp _context;

        public AbsenceController(MyContextApp context)
        {
            _context = context;
        }

        // GET: Absence/Create
        public IActionResult Create()
        {
            ViewBag.Classes = _context.Classe.Select(c => new { c.CodeClasse, c.NomClasse }).ToList();
            ViewBag.Matieres = _context.Matiere.Select(m => new { m.CodeMatiere, m.NomMatiere }).ToList();
            ViewBag.Enseignants = _context.Enseignant.Select(e => new { e.CodeEnseignant, e.Nom }).ToList();
            ViewBag.Seances = _context.Seance.Select(s => new { s.CodeSeance, s.NomSeance }).ToList();
            return View();
        }

        // POST: Absence/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FicheAbsenceSeance ficheAbsenceSeance)
        {
            if (ModelState.IsValid)
            {
                // Add the absence record
                _context.FicheAbsence.Add(ficheAbsenceSeance.FicheAbsence);
                _context.SaveChanges();

                // Set the IdFicheAbsence and add the related absence session record
                ficheAbsenceSeance.IdFicheAbsence = ficheAbsenceSeance.FicheAbsence.Id;
                _context.FicheAbsenceSeance.Add(ficheAbsenceSeance);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            // If the model is invalid, reload the drop-down lists
            ViewBag.Classes = _context.Classe.Select(c => new { c.CodeClasse, c.NomClasse }).ToList();
            ViewBag.Matieres = _context.Matiere.Select(m => new { m.CodeMatiere, m.NomMatiere }).ToList();
            ViewBag.Enseignants = _context.Enseignant.Select(e => new { e.CodeEnseignant, e.Nom }).ToList();
            ViewBag.Seances = _context.Seance.Select(s => new { s.CodeSeance, s.NomSeance }).ToList();

            return View(ficheAbsenceSeance);
        }

        // GET: Absence/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.FicheAbsenceSeance == null)
            {
                return NotFound();
            }

            var ficheAbsenceSeance = _context.FicheAbsenceSeance
                .Include(f => f.FicheAbsence)
                .FirstOrDefault(m => m.Id == id);

            if (ficheAbsenceSeance == null)
            {
                return NotFound();
            }

            ViewBag.Classes = _context.Classe.Select(c => new { c.CodeClasse, c.NomClasse }).ToList();
            ViewBag.Matieres = _context.Matiere.Select(m => new { m.CodeMatiere, m.NomMatiere }).ToList();
            ViewBag.Enseignants = _context.Enseignant.Select(e => new { e.CodeEnseignant, e.Nom }).ToList();
            ViewBag.Seances = _context.Seance.Select(s => new { s.CodeSeance, s.NomSeance }).ToList();

            return View(ficheAbsenceSeance);
        }

        // POST: Absence/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, FicheAbsenceSeance ficheAbsenceSeance)
        {
            if (id != ficheAbsenceSeance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.FicheAbsence.Update(ficheAbsenceSeance.FicheAbsence);
                    _context.FicheAbsenceSeance.Update(ficheAbsenceSeance);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.FicheAbsenceSeance.Any(e => e.Id == ficheAbsenceSeance.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            // Re-load the drop-down lists if model is invalid
            ViewBag.Classes = _context.Classe.Select(c => new { c.CodeClasse, c.NomClasse }).ToList();
            ViewBag.Matieres = _context.Matiere.Select(m => new { m.CodeMatiere, m.NomMatiere }).ToList();
            ViewBag.Enseignants = _context.Enseignant.Select(e => new { e.CodeEnseignant, e.Nom }).ToList();
            ViewBag.Seances = _context.Seance.Select(s => new { s.CodeSeance, s.NomSeance }).ToList();

            return View(ficheAbsenceSeance);
        }

        // GET: Absence/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || _context.FicheAbsenceSeance == null)
            {
                return NotFound();
            }

            var ficheAbsenceSeance = _context.FicheAbsenceSeance
                .Include(f => f.FicheAbsence)
                .FirstOrDefault(m => m.Id == id);

            if (ficheAbsenceSeance == null)
            {
                return NotFound();
            }

            return View(ficheAbsenceSeance);
        }

        // POST: Absence/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var ficheAbsenceSeance = _context.FicheAbsenceSeance
                .Include(f => f.FicheAbsence)
                .FirstOrDefault(m => m.Id == id);

            if (ficheAbsenceSeance != null)
            {
                _context.FicheAbsence.Remove(ficheAbsenceSeance.FicheAbsence);
                _context.FicheAbsenceSeance.Remove(ficheAbsenceSeance);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

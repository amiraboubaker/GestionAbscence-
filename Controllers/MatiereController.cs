using Microsoft.AspNetCore.Mvc;
using GestionAbscence.Models;
using GestionAbscence.Data;

namespace GestionAbscence.Controllers
{
    public class MatiereController : Controller
    {
        private readonly MyContextApp _context;

        public MatiereController(MyContextApp context)
        {
            _context = context;
        }

        // GET: Matiere
        public IActionResult Index()
        {
            var Matiere = _context.Matiere.ToList();
            return View(Matiere);
        }

        // GET: Matiere/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Matiere/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Matiere matiere)
        {
            if (ModelState.IsValid)
            {
                _context.Matiere.Add(matiere);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(matiere);
        }

        // GET: Matiere/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            var matiere = _context.Matiere.Find(id);
            if (matiere == null)
            {
                return NotFound();
            }
            return View(matiere);
        }

        // POST: Matiere/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Matiere matiere)
        {
            if (id != matiere.CodeMatiere)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Matiere.Update(matiere);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(matiere);
        }

        // GET: Matiere/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            var matiere = _context.Matiere.Find(id);
            if (matiere == null)
            {
                return NotFound();
            }

            return View(matiere);
        }

        // POST: Matiere/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var matiere = _context.Matiere.Find(id);
            if (matiere != null)
            {
                _context.Matiere.Remove(matiere);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

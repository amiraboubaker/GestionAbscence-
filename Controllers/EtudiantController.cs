using GestionAbscence.Data;
using GestionAbscence.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class EtudiantController : Controller
{
    private readonly MyContextApp _context;

    public EtudiantController(MyContextApp context)
    {
        _context = context;
    }

    // GET: Etudiant
    public async Task<IActionResult> Index()
    {
        // Fetch all students from the database
        var etudiants = await _context.Etudiant.ToListAsync().ConfigureAwait(false);
        return View(etudiants);
    }

    // GET: Etudiant/Create
    public IActionResult Create()
    {
        var etudiant = new Etudiant(); 
        return View(etudiant);
    }

    // POST: Etudiant/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Etudiant etudiant)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var e = new Etudiant{
    Nom = "Doe",
    Prenom = "John",
    Mail = "john.doe@example.com",
    DateNaissance = new DateTime(1995, 5, 15),
    CodeClasse = 1,
    NumInscription = 12345,
    Adresse = "123 Rue de Paris",
    Tel= "123456789"
};
                _context.Add(e);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Erreur lors de la création : {ex.Message}");
            }
        }
        return View(etudiant);
    }

    // GET: Etudiant/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (!id.HasValue)
        {
            return NotFound();
        }

        var etudiant = await _context.Etudiant.FindAsync(id.Value).ConfigureAwait(false);
        if (etudiant == null)
        {
            return NotFound();
        }

        return View(etudiant);
    }

    // POST: Etudiant/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,Mail")] Etudiant etudiant)
    {
        if (id != etudiant.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(etudiant);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtudiantExists(etudiant.Id))
                {
                    return NotFound();
                }
                throw;
            }
        }
        return View(etudiant);
    }

    // GET: Etudiant/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (!id.HasValue)
        {
            return NotFound();
        }

        var etudiant = await _context.Etudiant
            .FirstOrDefaultAsync(m => m.Id == id.Value)
            .ConfigureAwait(false);

        if (etudiant == null)
        {
            return NotFound();
        }

        return View(etudiant);
    }

    // GET: Etudiant/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (!id.HasValue)
        {
            return NotFound();
        }

        var etudiant = await _context.Etudiant
            .FirstOrDefaultAsync(m => m.Id == id.Value)
            .ConfigureAwait(false);

        if (etudiant == null)
        {
            return NotFound();
        }

        return View(etudiant);
    }

    // POST: Etudiant/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var etudiant = await _context.Etudiant.FindAsync(id).ConfigureAwait(false);
        if (etudiant != null)
        {
            _context.Etudiant.Remove(etudiant);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
        return RedirectToAction(nameof(Index));
    }

    // Helper method to check if a student exists
    private bool EtudiantExists(int id)
    {
        return _context.Etudiant.Any(e => e.Id == id);
    }
}

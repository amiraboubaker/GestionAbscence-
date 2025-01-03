using GestionAbscence.Data;
using GestionAbscence.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class EtudiantController : Controller
{
    private readonly MyContextApp _context;

    public EtudiantController(MyContextApp context)
    {
        _context = context;
    }

    // GET: Etudiant
    // GET: Etudiant
    public async Task<IActionResult> Index()
    {
        // Inclure les relations avec la classe et convertir NumInscription en string
        var etudiants = await _context.Etudiant
            .Select(e => new Etudiant
            {
                Id = e.Id,
                Nom = e.Nom,
                Prenom = e.Prenom,
                DateNaissance = e.DateNaissance,
                CodeClasse = e.CodeClasse,
                NumInscription = e.NumInscription,  // Laisser en tant qu'int ici
                Adresse = e.Adresse,
                Mail = e.Mail,
                Tel = e.Tel
            })
            .ToListAsync();

        // Retourner la vue avec la liste des étudiants
        return View(etudiants);
    }


    // GET: Etudiant/Create
    public async Task<IActionResult> Create()
    {
        ViewData["Classes"] = await _context.Classe.ToListAsync(); // Charger les classes pour un DropDownList
        return View();
    }

    // POST: Etudiant/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Nom,Prenom,DateNaissance,CodeClasse,NumInscription,Adresse,Mail,Tel")] Etudiant etudiant)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _context.Add(etudiant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Une erreur est survenue : {ex.Message}");
            }
        }

        ViewData["Classes"] = await _context.Classe.ToListAsync(); // Recharger les classes en cas d'échec
        return View(etudiant);
    }

    // GET: Etudiant/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (!id.HasValue)
        {
            return NotFound();
        }

        var etudiant = await _context.Etudiant.FindAsync(id.Value);
        if (etudiant == null)
        {
            return NotFound();
        }

        ViewData["Classes"] = await _context.Classe.ToListAsync();
        return View(etudiant);
    }

    // POST: Etudiant/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,DateNaissance,CodeClasse,NumInscription,Adresse,Mail,Tel")] Etudiant etudiant)
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
                await _context.SaveChangesAsync();
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

        ViewData["Classes"] = await _context.Classe.ToListAsync();
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
            .Include(e => e.Classe)
            .FirstOrDefaultAsync(m => m.Id == id.Value);

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
            .Include(e => e.Classe)
            .FirstOrDefaultAsync(m => m.Id == id.Value);

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
        var etudiant = await _context.Etudiant.FindAsync(id);
        if (etudiant != null)
        {
            try
            {
                _context.Etudiant.Remove(etudiant);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Une erreur est survenue : {ex.Message}");
            }
        }
        return RedirectToAction(nameof(Index));
    }

    // Helper method to check if a student exists
    private bool EtudiantExists(int id)
    {
        return _context.Etudiant.Any(e => e.Id == id);
    }
}

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
        return View(await _context.Etudiant.ToListAsync());
    }

    // GET: Etudiant/Create
    public IActionResult Create()
    {
        var etudiant = new Etudiant(); // Ensure this is not null
        return View(etudiant); // Pass a properly initialized model
    }

    // POST: Etudiant/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,Mail,DateNaissance,Classe,NumInscription,Adresse,Tel")] Etudiant etudiant)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _context.Add(etudiant); // Add the Etudiant object to the context
                await _context.SaveChangesAsync(); // Save changes to the database
                return RedirectToAction(nameof(Index)); // Redirect to the index view (listing page)
            }
            catch (Exception ex)
            {
                // You can log the error or handle exceptions here
                ModelState.AddModelError("", "An error occurred while saving the data.");
            }
        }
        return View(etudiant); // Return to the form with error messages if the model is invalid
    }



    // GET: Etudiant/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var etudiant = await _context.Etudiant.FindAsync(id);
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
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtudiantExists(etudiant.Id))
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
        return View(etudiant);
    }

    // GET: Etudiant/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var etudiant = await _context.Etudiant
            .FirstOrDefaultAsync(m => m.Id == id);
        if (etudiant == null)
        {
            return NotFound();
        }

        return View(etudiant);
    }

    // GET: Etudiant/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var etudiant = await _context.Etudiant
            .FirstOrDefaultAsync(m => m.Id == id);
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
        _context.Etudiant.Remove(etudiant);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool EtudiantExists(int id)
    {
        return _context.Etudiant.Any(e => e.Id == id);
    }
}

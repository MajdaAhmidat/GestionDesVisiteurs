using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gestion_des_visiteurs;
using gestion_des_visiteurs.Models;

namespace gestion_des_visiteurs.Controllers
{
    public class DemandesController : Controller
    {
        private readonly gestion_des_visiteursDbContext _context;

        public DemandesController(gestion_des_visiteursDbContext context)
        {
            _context = context;
        }

        // GET: Demandes
        public async Task<IActionResult> Index()
        {
            var gestion_des_visiteursDbContext = _context.Demandes.Include(d => d.Superviseur).Include(d => d.Visiteur);
            return View(await gestion_des_visiteursDbContext.ToListAsync());
        }

        // GET: Demandes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demande = await _context.Demandes
                .Include(d => d.Superviseur)
                .Include(d => d.Visiteur)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (demande == null)
            {
                return NotFound();
            }

            return View(demande);
        }

        // GET: Demandes/Create
        public IActionResult Create()
        {
            ViewData["idSuperviseur"] = new SelectList(_context.Superviseurs, "Id", "nom");
            ViewData["idVisiteur"] = new SelectList(_context.Visiteurs, "Id", "nom");
            return View();
        }

        // POST: Demandes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nom,description,idVisiteur,idSuperviseur")] Demande demande)
        {
            if (ModelState.IsValid)
            {
                var p = await _context.Visiteurs
               .FirstOrDefaultAsync(m => m.Id == demande.idVisiteur);
                demande.Visiteur = p ?? new Visiteur();

                var o = await _context.Superviseurs
               .FirstOrDefaultAsync(m => m.Id == demande.idSuperviseur);
                demande.Superviseur = o ?? new Superviseur();

                _context.Add(demande);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idSuperviseur"] = new SelectList(_context.Superviseurs, "Id", "cin", demande.idSuperviseur);
            ViewData["idVisiteur"] = new SelectList(_context.Visiteurs, "Id", "cin", demande.idVisiteur);
            return View(demande);
        }

        // GET: Demandes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demande = await _context.Demandes.FindAsync(id);
            if (demande == null)
            {
                return NotFound();
            }
            ViewData["idSuperviseur"] = new SelectList(_context.Superviseurs, "Id", "cin", demande.idSuperviseur);
            ViewData["idVisiteur"] = new SelectList(_context.Visiteurs, "Id", "cin", demande.idVisiteur);
            return View(demande);
        }

        // POST: Demandes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nom,description,idVisiteur,idSuperviseur")] Demande demande)
        {
            if (id != demande.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(demande);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DemandeExists(demande.Id))
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
            ViewData["idSuperviseur"] = new SelectList(_context.Superviseurs, "Id", "cin", demande.idSuperviseur);
            ViewData["idVisiteur"] = new SelectList(_context.Visiteurs, "Id", "cin", demande.idVisiteur);
            return View(demande);
        }

        // GET: Demandes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demande = await _context.Demandes
                .Include(d => d.Superviseur)
                .Include(d => d.Visiteur)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (demande == null)
            {
                return NotFound();
            }

            return View(demande);
        }

        // POST: Demandes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var demande = await _context.Demandes.FindAsync(id);
            if (demande != null)
            {
                _context.Demandes.Remove(demande);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DemandeExists(int id)
        {
            return _context.Demandes.Any(e => e.Id == id);
        }
    }
}

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
    public class VisitesController : Controller
    {
        private readonly gestion_des_visiteursDbContext _context;

        public VisitesController(gestion_des_visiteursDbContext context)
        {
            _context = context;
        }

        // GET: Visites
        public async Task<IActionResult> Index()
        {
            return View(await _context.Visites.ToListAsync());
        }

        // GET: Visites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visite = await _context.Visites
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visite == null)
            {
                return NotFound();
            }

            return View(visite);
        }

        // GET: Visites/Create
        public IActionResult Create()
        {
            ViewData["idVisiteur"] = new SelectList(_context.Visiteurs, "Id", "nom");
            return View();
        }

        // POST: Visites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("dateVisite,heureDebut,heureFin,duree,idVisiteur")] Visite visite)
        {
            if (ModelState.IsValid)
            {
                var p = await _context.Visiteurs
               .FirstOrDefaultAsync(m => m.Id == visite.idVisiteur);
                visite.Visiteur = p ?? new Visiteur();
                _context.Add(visite);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(visite);
        }

        // GET: Visites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visite = await _context.Visites.FindAsync(id);
            if (visite == null)
            {
                return NotFound();
            }
            return View(visite);
        }

        // POST: Visites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,dateVisite,heureDebut,heureFin,duree,idVisiteur")] Visite visite)
        {
            if (id != visite.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisiteExists(visite.Id))
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
            return View(visite);
        }

        // GET: Visites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visite = await _context.Visites
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visite == null)
            {
                return NotFound();
            }

            return View(visite);
        }

        // POST: Visites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visite = await _context.Visites.FindAsync(id);
            if (visite != null)
            {
                _context.Visites.Remove(visite);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisiteExists(int id)
        {
            return _context.Visites.Any(e => e.Id == id);
        }
    }
}

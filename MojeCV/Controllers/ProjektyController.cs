using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MojeCV.Data;
using MojeCV.Models;

namespace MojeCV.Controllers
{
    public class ProjektyController : Controller
    {
        private readonly CvContext _context;

        public ProjektyController(CvContext context)
        {
            _context = context;
        }

        // GET: Projekty
        public async Task<IActionResult> Index()
        {
            return View(await _context.Projekt.ToListAsync());
        }

        // GET: Projekty/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projekt = await _context.Projekt
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projekt == null)
            {
                return NotFound();
            }

            return View(projekt);
        }

        // GET: Projekty/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projekty/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa,Opis,Link")] Projekt projekt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projekt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projekt);
        }

        // GET: Projekty/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projekt = await _context.Projekt.FindAsync(id);
            if (projekt == null)
            {
                return NotFound();
            }
            return View(projekt);
        }

        // POST: Projekty/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,Opis,Link")] Projekt projekt)
        {
            if (id != projekt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projekt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjektExists(projekt.Id))
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
            return View(projekt);
        }

        // GET: Projekty/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projekt = await _context.Projekt
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projekt == null)
            {
                return NotFound();
            }

            return View(projekt);
        }

        // POST: Projekty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projekt = await _context.Projekt.FindAsync(id);
            if (projekt != null)
            {
                _context.Projekt.Remove(projekt);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjektExists(int id)
        {
            return _context.Projekt.Any(e => e.Id == id);
        }
    }
}

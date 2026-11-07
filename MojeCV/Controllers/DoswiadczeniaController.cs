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
    public class DoswiadczeniaController : Controller
    {
        private readonly CvContext _context;

        public DoswiadczeniaController(CvContext context)
        {
            _context = context;
        }

        // GET: Doswiadczenia
        public async Task<IActionResult> Index()
        {
            return View(await _context.Doswiadczenie.ToListAsync());
        }

        // GET: Doswiadczenia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doswiadczenie = await _context.Doswiadczenie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doswiadczenie == null)
            {
                return NotFound();
            }

            return View(doswiadczenie);
        }

        // GET: Doswiadczenia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doswiadczenia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Stanowisko,Firma,DataOd,DataDo,Opis")] Doswiadczenie doswiadczenie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doswiadczenie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doswiadczenie);
        }

        // GET: Doswiadczenia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doswiadczenie = await _context.Doswiadczenie.FindAsync(id);
            if (doswiadczenie == null)
            {
                return NotFound();
            }
            return View(doswiadczenie);
        }

        // POST: Doswiadczenia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Stanowisko,Firma,DataOd,DataDo,Opis")] Doswiadczenie doswiadczenie)
        {
            if (id != doswiadczenie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doswiadczenie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoswiadczenieExists(doswiadczenie.Id))
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
            return View(doswiadczenie);
        }

        // GET: Doswiadczenia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doswiadczenie = await _context.Doswiadczenie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doswiadczenie == null)
            {
                return NotFound();
            }

            return View(doswiadczenie);
        }

        // POST: Doswiadczenia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doswiadczenie = await _context.Doswiadczenie.FindAsync(id);
            if (doswiadczenie != null)
            {
                _context.Doswiadczenie.Remove(doswiadczenie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoswiadczenieExists(int id)
        {
            return _context.Doswiadczenie.Any(e => e.Id == id);
        }
    }
}

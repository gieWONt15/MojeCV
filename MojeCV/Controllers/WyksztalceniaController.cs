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
    public class WyksztalceniaController : Controller
    {
        private readonly CvContext _context;

        public WyksztalceniaController(CvContext context)
        {
            _context = context;
        }

        // GET: Wyksztalcenia
        public async Task<IActionResult> Index()
        {
            return View(await _context.Wyksztalcenie.ToListAsync());
        }

        // GET: Wyksztalcenia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wyksztalcenie = await _context.Wyksztalcenie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wyksztalcenie == null)
            {
                return NotFound();
            }

            return View(wyksztalcenie);
        }

        // GET: Wyksztalcenia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wyksztalcenia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Uczelnia,Kierunek,Stopien,RokOd,RokDo")] Wyksztalcenie wyksztalcenie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wyksztalcenie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wyksztalcenie);
        }

        // GET: Wyksztalcenia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wyksztalcenie = await _context.Wyksztalcenie.FindAsync(id);
            if (wyksztalcenie == null)
            {
                return NotFound();
            }
            return View(wyksztalcenie);
        }

        // POST: Wyksztalcenia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Uczelnia,Kierunek,Stopien,RokOd,RokDo")] Wyksztalcenie wyksztalcenie)
        {
            if (id != wyksztalcenie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wyksztalcenie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WyksztalcenieExists(wyksztalcenie.Id))
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
            return View(wyksztalcenie);
        }

        // GET: Wyksztalcenia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wyksztalcenie = await _context.Wyksztalcenie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wyksztalcenie == null)
            {
                return NotFound();
            }

            return View(wyksztalcenie);
        }

        // POST: Wyksztalcenia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wyksztalcenie = await _context.Wyksztalcenie.FindAsync(id);
            if (wyksztalcenie != null)
            {
                _context.Wyksztalcenie.Remove(wyksztalcenie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WyksztalcenieExists(int id)
        {
            return _context.Wyksztalcenie.Any(e => e.Id == id);
        }
    }
}

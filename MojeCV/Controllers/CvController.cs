using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MojeCV.Data;
using MojeCV.ViewModels;

namespace MojeCV.Controllers;

public class CvController : Controller
{
    private readonly CvContext _context;

    // kontekst dostarcza kontener DI zarejestrowany w Program.cs
    public CvController(CvContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var osoba = await _context.Osoba.FirstOrDefaultAsync();
        if (osoba == null)
            return RedirectToAction("Create", "Osoby");

        var model = new CvViewModel
        {
            Osoba = osoba,
            Doswiadczenia = await _context.Doswiadczenie
                .OrderByDescending(d => d.DataOd).ToListAsync(),
            Wyksztalcenie = await _context.Wyksztalcenie
                .OrderByDescending(w => w.RokOd).ToListAsync(),
            Umiejetnosci = await _context.Umiejetnosc
                .OrderByDescending(u => u.Poziom).ToListAsync(),
            Projekty = await _context.Projekt.OrderByDescending(p => p.Id).ToListAsync()
        };
        return View(model);
    }
}
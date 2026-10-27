using Microsoft.AspNetCore.Mvc;
using MojeCV.Models;
using MojeCV.ViewModels;

namespace MojeCV.Controllers;

public class CvController : Controller
{
    public IActionResult Index()
    {
        var model = new CvViewModel
        {
            Osoba = new Osoba
            {
                Imie = "Paweł",
                Nazwisko = "Gierlotka",
                Stanowisko = "Junior .NET Developer",
                Email = "chx101883@student.chorzow.merito.pl",
                Telefon = "662 - 047 - 787",
                Miasto = "Tychy",
                OMnie = "Inżynier informatyki, interesuję się aplikacjami webowymi."
            },
            Doswiadczenia = new()
            {
                new Doswiadczenie { Stanowisko = "Stażystka IT", Firma = "Hotel B&B Tychy", DataOd = new DateTime(2025, 10, 1), DataDo = new DateTime(2026, 9, 30), Opis = "Wsparcie zespołu przy migracji bazy danych. Obsługa 1st level support." },
                new Doswiadczenie { Stanowisko = "Co-CEO", Firma = "MediNAV", DataOd = new DateTime(2025, 10, 1), DataDo = new DateTime(2026, 10, 27)}
            },
            Umiejetnosci = new()
            {
                new Umiejetnosc { Nazwa = "C#", Poziom = 3 },
                new Umiejetnosc { Nazwa = "HTML/CSS", Poziom = 5 },
                new Umiejetnosc { Nazwa = "Git", Poziom = 4 },
                new Umiejetnosc { Nazwa = "JavaScript", Poziom = 4 },
                new Umiejetnosc { Nazwa = "SQL", Poziom = 3 },
            }
        };
        return View(model);
    }
}
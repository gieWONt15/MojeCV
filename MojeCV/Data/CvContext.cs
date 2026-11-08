using Microsoft.EntityFrameworkCore;
using MojeCV.Models;

namespace MojeCV.Data
{
    public class CvContext : DbContext
    {
        // Konstruktor przyjmujący opcje (np. adres bazy z pliku appsettings)
        public CvContext(DbContextOptions<CvContext> options) : base(options)
        {
        }

        // Tabela w bazie danych
        public DbSet<MojeCV.Models.Doswiadczenie> Doswiadczenie { get; set; } = default!;
        public DbSet<MojeCV.Models.Osoba> Osoba { get; set; } = default!;
        public DbSet<MojeCV.Models.Umiejetnosc> Umiejetnosc { get; set; } = default!;
        public DbSet<MojeCV.Models.Wyksztalcenie> Wyksztalcenie { get; set; } = default!;
        public DbSet<MojeCV.Models.Projekt> Projekt { get; set; } = default!;
    }
}
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
        public DbSet<Doswiadczenie> Doswiadczenie { get; set; }
        public DbSet<MojeCV.Models.Osoba> Osoba { get; set; } = default!;
    }
}
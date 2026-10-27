using MojeCV.Models;

namespace MojeCV.ViewModels;

public class CvViewModel
{
    public Osoba Osoba { get; set; } = new();
    public List<Doswiadczenie> Doswiadczenia { get; set; } = new();
    public List<Umiejetnosc> Umiejetnosci { get; set; } = new();
}
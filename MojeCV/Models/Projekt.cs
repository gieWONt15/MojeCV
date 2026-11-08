using System.ComponentModel.DataAnnotations;

namespace MojeCV.Models;

public class Projekt
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Podaj nazwę projektu.")]
    [StringLength(100)]
    public string Nazwa { get; set; } = string.Empty;
    
    [StringLength(1000)]
    public string? Opis { get; set; }

    [Display(Name = "Link do repozytorium (np. GitHub)")]
    [Url(ErrorMessage = "Wpisz poprawny adres URL (razem z https://)")]
    public string? Link { get; set; }
}
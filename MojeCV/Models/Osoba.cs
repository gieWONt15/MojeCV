using System.ComponentModel.DataAnnotations;

namespace MojeCV.Models
{
    public class Osoba
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Pole Imię jest wymagane.")]
        [StringLength(40, ErrorMessage = "Imie nie może być dłuższe niż 40 znaków.")]
        public string Imie { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Pole Nazwisko jest wymagane.")]
        [StringLength(40, ErrorMessage = "Nazwisko nie może być dłuższe niż 40 znaków.")]
        public string Nazwisko { get; set; } = string.Empty;
        public string Stanowisko { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Pole Email jest wymagane.")]
        [StringLength(40, ErrorMessage = "Imie nie może być dłuższe niż 40 znaków.")]
        [EmailAddress(ErrorMessage = "Pole Email nie jest wymagane.")]
        public string Email { get; set; } = string.Empty;
        public string? Telefon { get; set; }
        public string? Miasto { get; set; }
        
        [Display(Name = "O mnie")]
        public string? OMnie { get; set; }
    }
}

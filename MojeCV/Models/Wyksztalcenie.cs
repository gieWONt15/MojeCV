using System.ComponentModel.DataAnnotations;

namespace MojeCV.Models
{
    public class Wyksztalcenie
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Podaj nazwę uczelni")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Nazwa uczelni nie może być dłuższa niż 150 znaków")]
        public string Uczelnia { get; set; }
        
        [Required(ErrorMessage = "Podaj nazwę kierunku")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Nazwa kierunku nie może być dłuższa niż 150 znaków")]
        public string Kierunek { get; set; }

        public string? Stopien { get; set; } = string.Empty;
        
        [Range(1990, 2035, ErrorMessage = "Rok musi być z przedziału 1990-2035")]
        [Display(Name = "Od roku")]
        public int RokOd { get; set; }
        
        [Display(Name = "Do roku")]
        public int RokDo { get; set; }
    }
}

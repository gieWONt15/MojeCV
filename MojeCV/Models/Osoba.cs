namespace MojeCV.Models
{
    public class Osoba
    {
        public int Id { get; set; }
        public string Imie { get; set; } = string.Empty;
        public string Nazwisko { get; set; } = string.Empty;
        public string Stanowisko { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Telefon { get; set; }
        public string? Miasto { get; set; }
        public string? OMnie { get; set; }
    }
}

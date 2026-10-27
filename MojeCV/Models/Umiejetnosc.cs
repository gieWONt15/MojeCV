namespace MojeCV.Models
{
    public class Umiejetnosc
    {
        public int Id { get; set; }
        public string Nazwa { get; set; } = string.Empty;
        public int Poziom { get; set; }   // 1–5
        
        // Nowe pole do grupowania
        public string Kategoria { get; set; } = string.Empty; 
    }
}
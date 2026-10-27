namespace MojeCV.Models
{
    public class Wyksztalcenie
    {
        public int Id { get; set; }
        public string NazwaSzkoly { get; set; } = string.Empty;
        public DateTime DataStart { get; set; }
        public DateTime DataKoniec { get; set; }
        public string Miasto { get; set; } = string.Empty;
        public string TytulUzyskany { get; set; } = string.Empty;
    }
}

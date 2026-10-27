namespace MojeCV.Models
{
    public class Doswiadczenie
    {
        public int Id { get; set; }
        public string Stanowisko { get; set; } = "";
        public string Firma { get; set; } = "";
        public DateTime DataOd { get; set; }
        public DateTime? DataDo { get; set; }   // null = nadal pracuję
        public string? Opis { get; set; }
    }
}

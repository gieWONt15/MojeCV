namespace MojeCV.Models
{
    public class Doswiadczenie
    {
        public int Id { get; set; }
        public string Stanowisko { get; set; } = string.Empty;
        public string Firma { get; set; } = string.Empty;
        public DateTime DataOd { get; set; }
        public DateTime? DataDo { get; set; }   // null = nadal pracuję
        public string? Opis { get; set; }

        // Nowa właściwość obliczana
        public string CzasTrwania
        {
            get
            {
                // Jeśli DataDo jest nullem, przyjmujemy dzisiejszą datę
                DateTime koniec = DataDo ?? DateTime.Now;

                // Liczymy całkowitą różnicę w miesiącach 
                // (+1 zakłada, że pracowaliśmy przez cały miesiąc początkowy)
                int wszystkieMiesiace = ((koniec.Year - DataOd.Year) * 12) + koniec.Month - DataOd.Month + 1;

                // Logika formatowania tekstu
                if (wszystkieMiesiace < 12)
                {
                    return $"{wszystkieMiesiace} mies.";
                }
                
                int lata = wszystkieMiesiace / 12;
                int resztaMiesiecy = wszystkieMiesiace % 12;
                
                // Odmiana słowa "rok/lata/lat" (dla wartości 1-4, w CV rzadko potrzebujemy dokładniejszej deklinacji)
                string odmianaLat = lata == 1 ? "rok" : (lata >= 2 && lata <= 4 ? "lata" : "lat");

                if (resztaMiesiecy == 0)
                {
                    return $"{lata} {odmianaLat}";
                }

                return $"{lata} {odmianaLat} {resztaMiesiecy} mies.";
            }
        }
    }
}
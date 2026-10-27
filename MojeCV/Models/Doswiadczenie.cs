using System.ComponentModel.DataAnnotations;

namespace MojeCV.Models
{
    public class Doswiadczenie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole Stanowisko jest wymagane.")]
        [StringLength(100, ErrorMessage = "Stanowisko nie może być dłuższe niż 100 znaków.")]
        public string Stanowisko { get; set; } = string.Empty;

        [Required(ErrorMessage = "Firma to pole obowiązkowe.")]
        public string Firma { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data rozpoczęcia")]
        public DateTime DataOd { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data zakończenia")]
        public DateTime? DataDo { get; set; }

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
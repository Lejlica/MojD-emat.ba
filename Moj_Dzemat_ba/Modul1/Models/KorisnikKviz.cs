using FIT_Api_Example.Modul0_Autentifikacija.Models;

using FIT_Api_Example.Modul1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Modul2.Models
{
    public class KorisnikKviz
    { 
        [Key]
        public int id { get; set; }
        public DateTime vrijemePokretanja { get; set; }
        public DateTime? vrijemeZavrsetka { get; set; }
        public float? uspjeh { get; set; }


        [ForeignKey("korisnikPokrenuoId")]
        public KorisnickiNalog korisnikPokrenuo { get; set; }
        public int korisnikPokrenuoId { get; set; }

        [ForeignKey(nameof(AktivacijaKvizaId))]
        public AktivacijaKviza AktivacijaKviza { get; set; } = null!;
        public int AktivacijaKvizaId { get; set; }



    }
}

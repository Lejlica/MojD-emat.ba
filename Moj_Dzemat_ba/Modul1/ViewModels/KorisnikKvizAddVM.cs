using FIT_Api_Example.Modul0_Autentifikacija.Models;

using FIT_Api_Example.Modul1.Models;
using FIT_Api_Example.Modul2.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Modul1.ViewModels
{
    public class KorisnikKvizAddVM
    {
        public int id { get; set; }
        public DateTime vrijemePokretanja { get; set; }
        public DateTime? vrijemeZavrsetka { get; set; }
        public float? uspjeh { get; set; }
        public int korisnikPokrenuoId { get; set; }

        public int AktivacijaKvizaId { get; set; }

    }

}

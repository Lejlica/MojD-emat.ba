using FIT_Api_Example.Modul2.Models;

namespace FIT_Api_Example.Modul1.ViewModels
{
    public class DuhovnaVjezbaGetAllVM
    {
        public int id { get; set; }
        public string naslov { get; set; }
        public string opis { get; set; }
        public string tekst { get; set; }
        public DateTime datumPocetka { get; set; }
        public DateTime datumZavrsetka { get; set; }
        public bool isActive { get; set; }
        public string? slika_nova_base64 { get; set; }
        public int moderatorId { get; set; }

        public int trajanje { get; set; }
    }

}

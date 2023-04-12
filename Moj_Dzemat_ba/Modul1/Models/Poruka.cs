using FIT_Api_Example.Modul0_Autentifikacija.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Modul2.Models
{
    public class Poruka
    {
        public int Id { get; set; }
        public string Tekst { get; set; }

        public DateTime Vrijeme { get; set; }

        [ForeignKey("KorisnikId")]
        public Korisnik Korisnik { get; set; }
        public int KorisnikId { get; set; }

    }
}

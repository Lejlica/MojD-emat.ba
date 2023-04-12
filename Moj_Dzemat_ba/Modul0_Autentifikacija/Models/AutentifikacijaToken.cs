using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Example.Modul0_Autentifikacija.Models
{
    public class AutentifikacijaToken
    {
        [Key]
        public int id { get; set; }
        public string vrijednost { get; set; }
        [ForeignKey(nameof(korisnickiNalog))]
        public int KorisnickiNalogId { get; set; }
        public KorisnickiNalog korisnickiNalog { get; set; }
        public DateTime vrijemeEvidentiranja { get; set; }
        public string ipAdresa { get; set; }
        public string twoFcode { get; set; }
        public bool twoFcodeJelOtkljucan { get; set; }
    }
}

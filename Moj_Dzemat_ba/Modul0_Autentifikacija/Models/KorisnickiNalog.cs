using FIT_Api_Example.Modul2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FIT_Api_Example.Modul0_Autentifikacija.Models
{
    [Table("KorisnickiNalog")]
    public class KorisnickiNalog
    {
        [Key]
        public int id { get; set; }
        public string korisnickoIme { get; set; }
        [JsonIgnore]
        public string lozinka { get; set; }
        public string email { get; set; }
        //public byte[] slika_korisnika { get; set; }


        [JsonIgnore]
        public Korisnik? korisnik => this as Korisnik;

        [JsonIgnore]
        public Imam? imam => this as Imam;

        [JsonIgnore]
        public Moderator? moderator => this as Moderator;
        public bool isKorisnik => korisnik != null;
        public bool isImam => imam != null;
        public bool isModerator => moderator != null;
        public bool isAdmin { get; set; }
        public string? aktivacijaGUID { get; set; }
        public bool isAktiviran { get; set; }
    }
}

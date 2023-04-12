using FIT_Api_Example.Modul0_Autentifikacija.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Modul2.Models
{
    [Table("Clan")]
    public class Clan
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string OdnosSaNosiocem { get; set; }
        public string Status { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string? Napomena { get; set; }

        [ForeignKey("PorodicaID")]
        public Porodica Porodica { get; set; }
        public int PorodicaID { get; set; }

        public bool? Mekteb { get; set; }

    }
}

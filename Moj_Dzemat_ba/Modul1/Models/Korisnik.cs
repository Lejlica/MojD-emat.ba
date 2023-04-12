using FIT_Api_Example.Modul0_Autentifikacija.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Modul2.Models
{
    [Table("Korisnik")]
    public class Korisnik:KorisnickiNalog
    { 
       
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Telefon { get; set; }
        
        

        [ForeignKey("dzematId")]
        public Dzemat dzemat { get; set; }
        public int dzematId { get; set; }


    }
}

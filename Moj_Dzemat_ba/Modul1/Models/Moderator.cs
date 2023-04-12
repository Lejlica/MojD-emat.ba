using FIT_Api_Example.Modul0_Autentifikacija.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Modul2.Models
{
    [Table("Moderator")]
    public class Moderator:KorisnickiNalog
    { 
        
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }
     

    }
}

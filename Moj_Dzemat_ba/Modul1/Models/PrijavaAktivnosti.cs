using FIT_Api_Example.Modul0_Autentifikacija.Models;
using FIT_Api_Example.Modul1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Modul2.Models
{
    public class PrijavaAktivnosti
    {
        [Key]
        public int Id { get; set; }
        public DateTime VrijemePrijave { get; set; }


        [ForeignKey("korisnickiNalogPrijavljenogId")]
        public KorisnickiNalog korisnickiNalogPrijavljenog { get; set; }
        public int korisnickiNalogPrijavljenogId { get; set; }

        [ForeignKey("AktivnostId")]
        public Aktivnost Aktivnost { get; set; }
        public int AktivnostId { get; set; }




    }
}

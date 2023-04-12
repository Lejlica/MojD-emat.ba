using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Modul2.Models
{
    public class Porodica
    { 
        [Key]
        public int Id { get; set; }
        public string Prezime { get; set; }
        public string NosiocPorodice { get; set; }
        public string Adresa { get; set; }
        public string BrojTelefona { get; set; }
        public string Lokacija { get; set; }
        public bool ClanoviIZ { get; set; }
        public bool ClanoviHarema { get; set; }

        [ForeignKey("dzematId")]
        public Dzemat dzemat { get; set; }
        public int dzematId { get; set; }

    }
}

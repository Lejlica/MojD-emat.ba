   using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Example.Modul2.Models
{
    public class Muftijstvo
    { 
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public string Fax { get; set; }
        public string Informacije { get; set; }
        public string KontaktOsoba { get; set; }



    }
}

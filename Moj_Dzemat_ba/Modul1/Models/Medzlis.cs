using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Modul2.Models
{
    public class Medzlis
    { 
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public string Fax { get; set; }
        public string Informacije { get; set; }

        [ForeignKey("MuftijstvoId")]
        public Muftijstvo Muftijstvo { get; set; }
        public int MuftijstvoId { get; set; }

    }
}

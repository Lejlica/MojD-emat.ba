using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Modul2.Models
{
    public class Dzemat
    { 
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string KratkiOpis { get; set; }
        public string DzematskiOdbor { get; set; }
        public byte[] slika_dzemata_bytes { get; set; }
        public string LokacijaDzamije { get; set; }
        public string Informacije { get; set; }

        [ForeignKey("MedzlisId")]
        public Medzlis Medzlis { get; set; }
        public int MedzlisId { get; set; }

    }
}

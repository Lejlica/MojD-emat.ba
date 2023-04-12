using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Modul2.Models
{
    public class Slika
    { 
        [Key]
        public int ID { get; set; }
        public string Opis { get; set; }
        public byte[] Image { get; set; }

        [ForeignKey("VijestId")]
        public Vijest Vijest { get; set; }
        public int VijestId { get; set; }




    }
}

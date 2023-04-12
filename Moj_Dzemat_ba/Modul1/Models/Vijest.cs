using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Modul2.Models
{
    public class Vijest
    { 
        [Key]
        public int Id { get; set; }
        public string Naslov { get; set; }
        public string Tekst { get; set; }
        public string Autor { get; set; }
        public DateTime Datum { get; set; }
        public byte[] slika_bajtovi { get; set; }
        public string Opis { get; set; }

        [ForeignKey("ImamId")]
        public Imam Imam { get; set; }
        public int ImamId { get; set; }


    }
}

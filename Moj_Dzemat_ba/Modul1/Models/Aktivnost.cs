using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Modul2.Models
{
    public class Aktivnost
    { 
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public DateTime Datum { get; set; }
        public string Lokacija { get; set; }

        [ForeignKey("ImamId")]
        public Imam Imam { get; set; }
        public int ImamId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Modul2.Models
{
    public class DnevnaVjezba
    { 
        [Key]
        public int Id { get; set; }
        public string Naslov { get; set; }
        public string Uvod { get; set; }
        public string Tekst { get; set; }
        public DateTime DatumObjave { get; set; }

        [ForeignKey("DuhovnaVjezbaId")]
        public DuhovnaVjezba DuhovnaVjezba { get; set; }
        public int DuhovnaVjezbaId { get; set; }


    }
}

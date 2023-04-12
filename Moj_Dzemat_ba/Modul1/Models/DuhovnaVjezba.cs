using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Modul2.Models
{
    public class DuhovnaVjezba
    { 
        [Key]
        public int Id { get; set; }
        public string Naslov { get; set; }
        public string Opis { get; set; }
        public string Tekst { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumZavrsetka { get; set; }
        public bool IsActive { get; set; }
        public byte[] slika_korisnika_bytes { get; set; }

        [ForeignKey("ModeratorId")]
        public Moderator Moderator { get; set; }
        public int ModeratorId { get; set; }
        

    }
}

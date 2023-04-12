using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Modul2.Models
{
    public class MojeVjezbe
    { 
        [Key]
        public int Id { get; set; }
        public bool IsFinished { get; set; }

        [ForeignKey("KorisnikId")]
        public Korisnik Korisnik { get; set; }
        public int KorisnikId { get; set; }

        [ForeignKey("DuhovnaVjezbaId")]
        public DuhovnaVjezba DuhovnaVjezba { get; set; }
        public int DuhovnaVjezbaId { get; set; }


    }
}

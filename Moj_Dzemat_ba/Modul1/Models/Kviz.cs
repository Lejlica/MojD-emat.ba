using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Modul2.Models
{
    public class Kviz
    { 
        [Key]
        public int id { get; set; }
        public string naziv { get; set; }
        public string vrstaKviza { get; set; }
        public DateTime datumKviza { get; set; }
        public int brojPitanja { get; set; }
        public string opis { get; set; }

        [ForeignKey(nameof(moderator))]
        public int moderator_Id { get; set; }
        public Moderator moderator { get; set; }


    }
}

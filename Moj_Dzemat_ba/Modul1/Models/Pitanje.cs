using FIT_Api_Example.Modul1.Models;
using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Example.Modul2.Models
{
    public class Pitanje
    { 
        [Key]
        public int id { get; set; }
        public string tekst { get; set; }
        public bool isActive { get; set; }
        public int bodovi { get; set; }
        public virtual List<PonudjeniOdgovor> ponudjeniOdgovori { get; set; } = null!;

    }
}

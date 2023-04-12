using FIT_Api_Example.Modul1.Models;
using FIT_Api_Example.Modul2.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Modul1.ViewModels
{
    public class PrijavaAktivnostiAddVM
    {
        public int id { get; set; }
        public DateTime vrijemePrijave { get; set; }
        public int korisnikId { get; set; }
        public int aktivnost_id { get; set; }

    }

}

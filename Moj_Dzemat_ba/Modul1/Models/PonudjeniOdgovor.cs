using FIT_Api_Example.Modul2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FIT_Api_Example.Modul1.Models
{
    public class PonudjeniOdgovor
    {
        [Key]
        public int id { get; set; }
        public string tekst { get; set; }
        [JsonIgnore]
        public bool isCorrect { get; set; }

        [ForeignKey(nameof(pitanjeId))] 
        [JsonIgnore]
        public virtual Pitanje Pitanje { get; set; } = null!;
        public int pitanjeId { get; set; }
    }
}

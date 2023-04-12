using FIT_Api_Example.Modul2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FIT_Api_Example.Modul1.Models
{
    public class KorisnikKvizPitanja
    {
        [Key]
        public int id { get; set; }
        
        [ForeignKey(nameof(KorisnikKvizId))]
        [JsonIgnore]
        public virtual KorisnikKviz KorisnikKviz { get; set; } = null!;
        public int KorisnikKvizId { get; set; }

        [ForeignKey(nameof(PitanjeId))]
        public virtual Pitanje Pitanje { get; set; } = null!;
        public int PitanjeId { get; set; }

        public float? maxBodovi { get; set; }
        public float? ostvareniBodovi { get; set; }

        public string? oznaceniOdgTekst { get; set; }

        [JsonIgnore]
        public string? OznaceniOdgovoriIDsString { get; set; }

        [NotMapped]
        public List<int> OznaceniOdgovoriIDs
        {
            get => JsonSerializer.Deserialize<List<int>>(OznaceniOdgovoriIDsString ?? "[]") ?? new List<int>();
            set => OznaceniOdgovoriIDsString = JsonSerializer.Serialize(value);
        }


    }
}

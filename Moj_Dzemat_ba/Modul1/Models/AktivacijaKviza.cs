
using FIT_Api_Example.Modul2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FIT_Api_Example.Modul1.Models
{
    public class AktivacijaKviza
    {
        [Key]
        public int id { get; set; }
        public string naziv { get; set; }
        public float trajanjeMinute { get; set; }
        public DateTime pocetak { get; set; }
        public DateTime kraj { get; set; }

        [ForeignKey(nameof(KvizId))]
        public virtual Kviz Kviz { get; set; } = null!;
        public int KvizId { get; set; }
    }
}

using FIT_Api_Example.Modul1.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Modul2.Models
{
    public class KvizPitanje
    { 
        [Key]
        public int id { get; set; }

        [ForeignKey("kvizId")]
        public Kviz Kviz { get; set; }
        public int kvizId { get; set; }
        [ForeignKey("pitanjeId")]
        public Pitanje Pitanje { get; set; }
        public int pitanjeId { get; set; }
        
    }
}

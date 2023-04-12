namespace FIT_Api_Example.Modul1.ViewModels
{
    public class KvizAddVM
    {
        public int id { get; set; }
        public string naziv { get; set; }
        public string vrstaKviza { get; set; }
        public DateTime datumKviza { get; set; }
        public int brojPitanja { get; set; }
        public int moderatorId { get; set; }
        public string opis { get; set; }
    }

}

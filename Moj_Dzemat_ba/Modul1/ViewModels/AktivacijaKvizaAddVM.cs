namespace FIT_Api_Example.Modul1.ViewModels
{
    public class AktivacijaKvizaAddVM
    {
        public int id { get; set; }
        public string naziv { get; set; }
        public float trajanjeMinute { get; set; }
        public DateTime pocetak { get; set; }
        public DateTime kraj { get; set; }
        public int KvizId { get; set; }
    }
}

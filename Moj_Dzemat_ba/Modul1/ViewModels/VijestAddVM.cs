namespace FIT_Api_Example.Modul1.ViewModels
{
    public class VijestAddVM
    {
        public int id { get; set; }
        public string naslov { get; set; }
        public string tekst { get; set; }
        public DateTime datum { get; set; }
        public int ImamId { get; set; }
        public string autor { get; set; }
        public string? image_nova_base64 { get; set; }
        public string opis { get; set; }

    }

}

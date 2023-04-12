namespace FIT_Api_Example.Modul1.ViewModels
{
    public class ImamAddVM
    {
        public int id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string email { get; set; }
        public string telefon { get; set; }
        public string password { get; set; }
        public DateTime datumRodjenja { get; set; }
        public int dzematId { get; set; }
        public string username { get; set; }
        public string salt { get; set; }
        public bool fakultet { get; set; }
        public string? slika_nova_base64 { get; set; }
        public string biografija { get; set; }

    }

}

namespace FIT_Api_Example.Modul1.ViewModels
{
    public class DzematAddVM
    {
        public int id { get; set; }
        public string naziv { get; set; }
        public string lokacijaDzamije { get; set; }
        public string info { get; set; }
        public string kratkiOpis { get; set; }
        public string dzematskiOdbor { get; set; }
        public int MedzlisId { get; set; }
        public string? slika_nova_base64 { get; set; }
    }

}

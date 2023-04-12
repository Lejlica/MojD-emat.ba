using FIT_Api_Example.Modul2.Models;

namespace FIT_Api_Example.Modul1.ViewModels
{
    public class PorodicaGetVM
    {
        public int id { get; set; }
        public string prezime { get; set; }
        public string nosiocPorodice { get; set; }
        public string adresa { get; set; }
        public string telefon { get; set; }
        public string lokacija { get; set; }
        public bool clanoviIZ { get; set; }
        public bool clanoviHarema { get; set; }
        public int dzematId { get; set; }
    }

}

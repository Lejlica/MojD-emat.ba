using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Modul1.ViewModels;
using FIT_Api_Example.Modul2.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Example.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class KorisnikController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public KorisnikController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }



        [HttpPost]
        public ActionResult Snimi([FromBody] KorisnikAddVM x)
        {
            Korisnik? objekat = new Korisnik();
            _dbContext.Add(objekat);

            var korisnici = _dbContext.Korisnik.ToList();
            for (int i = 0; i < korisnici.Count; i++)
            {
                if (korisnici[i].korisnickoIme == x.korisnickoIme)
                    return BadRequest("korisnicko ime je vec u bazi");
            }
            //if (x.id == 0)
            //{
            //    objekat = new Korisnik();
            //    _dbContext.Add(objekat);//priprema sql
            //}
            //else
            //{
            //    objekat = _dbContext.Korisnik.Find(x.id);
            //}

            // objekat.id = x.id;
            objekat.Ime = x.ime;
            objekat.Prezime = x.prezime;
            objekat.lozinka = x.password;
            objekat.korisnickoIme = x.korisnickoIme;
            objekat.DatumRodjenja = x.datumRodjenja;
            objekat.Telefon = x.telefon;
            objekat.dzematId = x.dzematId;
            objekat.email = x.email;

            _dbContext.SaveChanges(); //exceute sql -- update Predmet set ... where...
            return Ok(objekat);
        }

        public class KorisnikAddVM2
        {
            public string ime { get; set; }
            public string prezime { get; set; }
            //public string korisnickoIme { get; set; }
            public string email { get; set; }
            public string telefon { get; set; }

        }

        [HttpPost]
        public ActionResult SnimiProfPostav(int id, [FromBody] KorisnikAddVM2 x)
        {
            Korisnik? objekat;


            objekat = _dbContext.Korisnik.Find(id);



            objekat.Ime = x.ime;
            objekat.Prezime = x.prezime;
            //objekat.korisnickoIme = x.korisnickoIme;
            objekat.Telefon = x.telefon;


            _dbContext.SaveChanges(); //exceute sql -- update Predmet set ... where...
            return Ok(objekat);
        }

        [HttpGet]
        public ActionResult GetAll(int id)
        {
            //int nalogId = HttpContext.GetLoginInfo().korisnickiNalog.id;
            //string lozinka = HttpContext.GetLoginInfo().korisnickiNalog.lozinka;
            //string korisnickoIme = HttpContext.GetLoginInfo().korisnickiNalog.korisnickoIme;
            //Korisnik ? korisnik = _dbContext.Korisnik.FirstOrDefault(x => x.id == nalogId);
            //.Where(k => k.id == korisnik.id)
            var data = _dbContext.Korisnik.Where(k => k.id == id)

                .Select(s => new
                {
                    //id= s.id,
                    ime = s.Ime,
                    prezime = s.Prezime,
                    telefon = s.Telefon,
                    email=s.email
                })
                .SingleOrDefault();
            return Ok(data);
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            Korisnik? korisnik = _dbContext.Korisnik.Find(id);

            if (korisnik == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(korisnik);

            _dbContext.SaveChanges();
            return Ok(korisnik);
        }
    }
}

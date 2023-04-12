using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Example.Modul0_Autentifikacija.Models;
using FIT_Api_Example.Modul1.ViewModels;
using FIT_Api_Example.Modul2.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Example.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class KorisnickiNalogController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public KorisnickiNalogController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

     public class KorisnickiNalogAddVM
     {
          public string lozinka { get; set; }
          public string staraLozinka { get; set; }
          public string korisnickoIme { get; set; }

        }
        [HttpPost]
        public ActionResult Snimi(int id,[FromBody] KorisnickiNalogAddVM x)
        {

            KorisnickiNalog? objekat;
            objekat = _dbContext.KorisnickiNalog.FirstOrDefault(k => k.id == id);

            var korisnickiNalozi = _dbContext.KorisnickiNalog.ToList();
            for (int i = 0; i < korisnickiNalozi.Count; i++)
            {
                if (korisnickiNalozi[i].korisnickoIme == x.korisnickoIme && id != korisnickiNalozi[i].id)
                    return BadRequest("korisnicko ime je vec u bazi");
            }

            //KorisnickiNalog? objekat;

            //if (id == 0)
            //{
            //    objekat = new KorisnickiNalog();
            //    _dbContext.Add(objekat);//priprema sql
            //}
            //else
            //{
            //    objekat = _dbContext.KorisnickiNalog.FirstOrDefault(k=>k.id==id);
            //}

            if (objekat.lozinka == x.staraLozinka)
            {
                objekat.lozinka = x.lozinka;
                if(x.korisnickoIme=="")
                {
                    objekat.korisnickoIme = HttpContext.GetLoginInfo().korisnickiNalog.korisnickoIme;
                }
                objekat.korisnickoIme = x.korisnickoIme;
            }
            else
            {
                return BadRequest("passwords dont match");
            }   
            
            
            _dbContext.SaveChanges(); //exceute sql -- update Predmet set ... where...
            return Ok(objekat);
        }

        public class KorisnickiNalogAddVM2
        {
            public string Ime { get; set; }
            public string Prezime { get; set; }
            //public string korisnickoIme { get; set; }
            public string Email { get; set; }
            public string Telefon { get; set; }

        }

        [HttpPost]
        public ActionResult Snimi2(int id, [FromBody] KorisnickiNalogAddVM2 x)
        {
            KorisnickiNalog? objekat;

            if (id == 0)
            {
                objekat = new KorisnickiNalog();
                _dbContext.Add(objekat);//priprema sql
            }
            else
            {
                objekat = _dbContext.KorisnickiNalog.FirstOrDefault(k => k.id == id);
            }

            
            objekat.korisnik.Ime = x.Ime;
            objekat.korisnik.Prezime = x.Prezime;
            //objekat.korisnickoIme = x.korisnickoIme;
            objekat.korisnik.Telefon = x.Telefon;
            objekat.email = x.Email;

            
           
            _dbContext.SaveChanges(); //exceute sql -- update Predmet set ... where...
            return Ok(objekat);
        }


    }
}

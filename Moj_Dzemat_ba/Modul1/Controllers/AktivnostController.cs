using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Example.Modul1.ViewModels;
using FIT_Api_Example.Modul2.Models;
using Microsoft.AspNetCore.Mvc;


namespace FIT_Api_Example.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class AktivnostController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public AktivnostController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

     
        [HttpPost]
        public ActionResult<Aktivnost> Snimi([FromBody] AktivnostAddVM x)
        {
           if(x.datum<DateTime.Now)
            {
                return BadRequest("nemoguce dodati aktivnost sa datumom koji je prosao");
            }

            Aktivnost? objekat;

            if (x.id == 0)
            {
                objekat = new Aktivnost();
                _dbContext.Add(objekat);//priprema sql
            }
            else
            {
                objekat = _dbContext.Aktivnost.Find(x.id);
            }

            objekat.Id = x.id;
            objekat.Naziv = x.naziv;
            objekat.Opis=x.opis;
            objekat.Datum = x.datum;
            objekat.Lokacija = x.lokacija;
            objekat.ImamId = HttpContext.GetLoginInfo().korisnickiNalog.id;
            

            _dbContext.SaveChanges(); //exceute sql -- update Predmet set ... where...
            return objekat;
        }

        [HttpGet]
        [Autorizacija(moderator: true, imam: true, korisnik: false, admin: false)]
        public ActionResult GetBrojPrijavaNaAktivnost(int aktivnost_id)
        {
            
            var brojPrijavaNaAktivnost = _dbContext.PrijavaAktivnosti.Where(p => p.AktivnostId == aktivnost_id).Count();
            return Ok(brojPrijavaNaAktivnost);
        }

        [HttpGet]
        [Autorizacija(moderator: true, imam: true, korisnik: true, admin: true)]
        public ActionResult GetAktivne()
        {
            //var aktivnost = _dbContext.Aktivnost.Where(a => a.Imam.dzematId == HttpContext.GetLoginInfo().korisnickiNalog.korisnik.dzematId || a.Imam.dzematId == HttpContext.GetLoginInfo().korisnickiNalog.imam.dzematId);
            //var aktuelne_aktivnosti = _dbContext.Aktivnost.Where(a => (a.Imam.dzematId == HttpContext.GetLoginInfo().korisnickiNalog.korisnik.dzematId || a.Imam.dzematId == HttpContext.GetLoginInfo().korisnickiNalog.imam.dzematId) && a.Datum > DateTime.Now).Select(s => new AktivnostGetVM
            var aktuelne_aktivnosti = _dbContext.Aktivnost.OrderByDescending(a=>a.Id).Where(a => a.Datum > DateTime.Now).Select(s => new AktivnostGetVM
            {
                id=s.Id,
                naziv = s.Naziv,
                opis = s.Opis,
                datum = s.Datum,
                lokacija = s.Lokacija
            }).ToList();

           
            return Ok(aktuelne_aktivnosti);
        }
        [HttpGet]
        [Autorizacija(moderator: true, imam: true, korisnik: true, admin: true)]
        public ActionResult GetZavrsene()
        {
            var zavrsene_aktivnosti = _dbContext.Aktivnost.Where(a => a.Datum < DateTime.Now).Select(s => new AktivnostGetVM
            {
                naziv = s.Naziv,
                opis = s.Opis,
                datum = s.Datum,
                lokacija = s.Lokacija
            }).ToList();

            return Ok(zavrsene_aktivnosti);
        }
        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            Aktivnost? akt = _dbContext.Aktivnost.Find(id);

            if (akt == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(akt);

            _dbContext.SaveChanges();
            return Ok(akt);
        }
    }
}

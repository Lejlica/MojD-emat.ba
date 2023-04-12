using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Example.Modul0_Autentifikacija.Models;
using FIT_Api_Example.Modul1.ViewModels;
using FIT_Api_Example.Modul2.Models;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class PrijavaAktivnostiController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public PrijavaAktivnostiController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

     
        [HttpPost]
        public ActionResult Snimi(int aktivnost_id,[FromBody] PrijavaAktivnostiAddVM x)
        {
            
            PrijavaAktivnosti? objekat;
           // objekat = _dbContext.PrijavaAktivnosti.FirstOrDefault(k => k.Id == aktivnost_id);

            var listaPrijavaKorisnika = _dbContext.PrijavaAktivnosti.Where(a=>a.korisnickiNalogPrijavljenogId== HttpContext.GetLoginInfo().korisnickiNalog.id).ToList();
            
            

            for (int i = 0; i < listaPrijavaKorisnika.Count; i++)
            {
                if (listaPrijavaKorisnika[i].AktivnostId == aktivnost_id)
                    return BadRequest("prijava na aktivnost je moguca samo jednom");
            }

            objekat = new PrijavaAktivnosti();  
            _dbContext.Add(objekat);
            
            //if (aktivnost_id == 0)
            //{
            //    objekat = new PrijavaAktivnosti();
            //    _dbContext.Add(objekat);//priprema sql
            //}
            //else
            //{
            //    objekat = _dbContext.PrijavaAktivnosti.Find(aktivnost_id);
            //}

            objekat.AktivnostId = aktivnost_id;
            objekat.VrijemePrijave=DateTime.Now;
           
            objekat.korisnickiNalogPrijavljenog = HttpContext.GetLoginInfo().korisnickiNalog;



            _dbContext.SaveChanges(); //exceute sql -- update Predmet set ... where...
            return Ok(objekat);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var data = _dbContext.PrijavaAktivnosti
                .OrderBy(s => s.Id)
                .Select(s => new 
                {
                    id = s.Id,
                    aktivnosti=s.Aktivnost.Naziv,
                    vrijemePrijave = s.VrijemePrijave,
                    dzematlija=s.korisnickiNalogPrijavljenog.korisnickoIme

                    
                })
                .AsQueryable();
            return Ok(data.Take(100).ToList());
        }

        

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            Aktivnost prijavljenjaAktivnost = _dbContext.Aktivnost.SingleOrDefault(a => a.Id == id);
            KorisnickiNalog prijavljeniKorisnik = HttpContext.GetLoginInfo().korisnickiNalog;

            PrijavaAktivnosti? pa = _dbContext.PrijavaAktivnosti.FirstOrDefault(p => p.AktivnostId == prijavljenjaAktivnost.Id &&
            p.korisnickiNalogPrijavljenogId == prijavljeniKorisnik.id);

            if (pa == null)
                _dbContext.Aktivnost.Remove(prijavljenjaAktivnost);
            else
            { _dbContext.Remove(pa);
                _dbContext.Remove(prijavljenjaAktivnost);
            }
           

            _dbContext.SaveChanges();
            return Ok(pa);
        }
    }
}

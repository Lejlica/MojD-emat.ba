using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Example.Modul1.Models;
using FIT_Api_Example.Modul1.ViewModels;
using FIT_Api_Example.Modul2.Models;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class KorisnikKvizController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public KorisnikKvizController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpPost]
        public ActionResult Snimi([FromBody] KorisnikKvizAddVM x)
        {
            KorisnikKviz? objekat;

            //float maxBodovi = 0;

            objekat = new KorisnikKviz();
            _dbContext.Add(objekat);//priprema sql

            var kvizId = _dbContext.AktivacijaKviza.Where(s => s.id == x.AktivacijaKvizaId).Select(s => s.KvizId).FirstOrDefault();
            var pitanje = _dbContext.KvizPitanje.Where(k => k.kvizId == kvizId).Select(p => p.Pitanje).ToList();
            var aktivacija = _dbContext.AktivacijaKviza.Find(x.AktivacijaKvizaId);

            objekat.id = x.id;
            objekat.korisnikPokrenuoId = HttpContext.GetLoginInfo().korisnickiNalog.id;
            objekat.korisnikPokrenuo = HttpContext.GetLoginInfo().korisnickiNalog;
            objekat.vrijemePokretanja = DateTime.Now;
            objekat.AktivacijaKviza = aktivacija;
            objekat.AktivacijaKvizaId = aktivacija.id;


            //for (int i = 0; i < pitanje.Count; i++)
            //{
            //     maxBodovi += pitanje[i].bodovi;
            //}



            _dbContext.SaveChanges(); //exceute sql -- update Predmet set ... where...
            return Ok(objekat);
        }

        [HttpGet]
        public ActionResult GetAll(int kvizId)
        {
            var data = _dbContext.KorisnikKviz.Where(x=>x.korisnikPokrenuo.id==HttpContext.GetLoginInfo().korisnickiNalog.id && x.AktivacijaKviza.KvizId==kvizId)
                .OrderByDescending(s => s.id)
                .Select(s => new 
                {
                    id = s.id,
                    vrijemePokretanja = s.vrijemePokretanja,
                    AktivacijaKvizaId=s.AktivacijaKvizaId,
                    korisnikPokrenuoId= s.korisnikPokrenuoId,
                })
                .AsQueryable();
            return Ok(data.Take(1).ToList());
        }
    }
}

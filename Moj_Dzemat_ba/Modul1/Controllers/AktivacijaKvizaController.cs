using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Modul1.Models;
using FIT_Api_Example.Modul1.ViewModels;
using FIT_Api_Example.Modul2.Models;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class AktivacijaKvizaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public AktivacijaKvizaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpPost]
        public ActionResult Add([FromBody] AktivacijaKvizaAddVM x)
        {
            AktivacijaKviza aktivacija;

            if (x.id == 0)
            {
                aktivacija = new AktivacijaKviza();
                _dbContext.Add(aktivacija);
            }
            else
            {
                aktivacija = _dbContext.AktivacijaKviza.Find(x.id);
            };

            aktivacija.id = x.id;
            aktivacija.pocetak = x.pocetak;
            aktivacija.trajanjeMinute = x.trajanjeMinute;
            aktivacija.kraj = x.kraj; //DateTime.Parse((x.pocetak.Minute + x.trajanjeMinute).ToString());
            aktivacija.naziv = x.naziv;
            aktivacija.KvizId = x.KvizId;



            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            //var kvizPitanje = _dbContext.KvizPitanje.ToList();
            //var kvizId=_dbContext.Kviz.Find(kvizPitanje.Select(k=>k.id));

            var data = _dbContext.AktivacijaKviza
               .OrderBy(s => s.id)
               .Select(s => new
               {

                   id = s.id,
                   kvizId = s.Kviz.id,
                   pitanjeId = _dbContext.KvizPitanje.Where(k => k.kvizId == s.Kviz.id).Select(k => k.pitanjeId).FirstOrDefault(),
                   tekst = _dbContext.KvizPitanje.Where(k => k.kvizId == s.Kviz.id).Select(s => s.Pitanje.tekst).FirstOrDefault(),
                   naziv = s.Kviz.naziv,
                   ponudjeniOdgovori = _dbContext.KvizPitanje.Where(k => k.kvizId == s.Kviz.id).Select(s => s.Pitanje.ponudjeniOdgovori).FirstOrDefault(),
                   opis = s.Kviz.opis
                   //isActive = s.Pitanje.isActive,
                   //isCorrect1 = s.Pitanje.ponudjeniOdgovori[0].isCorrect,
                   //isCorrect2 = s.Pitanje.ponudjeniOdgovori[1].isCorrect,
                   //isCorrect3 = s.Pitanje.ponudjeniOdgovori[2].isCorrect,
                   //isCorrect4 = s.Pitanje.ponudjeniOdgovori[3].isCorrect,
                   //isCorrect=_dbContext.PonudjeniOdgovor.FirstOrDefault(x=>x.pitanjeId==s.pitanjeId).isCorrect

               }).ToList();
            return Ok(data);

        }


        //[HttpPost("{id}")]
        //public ActionResult Delete(int id)
        //{

        //}
    }
}

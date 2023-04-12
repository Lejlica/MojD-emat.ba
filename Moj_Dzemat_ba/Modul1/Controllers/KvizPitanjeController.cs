using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Modul1.Models;
using FIT_Api_Example.Modul1.ViewModels;
using FIT_Api_Example.Modul2.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace FIT_Api_Example.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class KvizPitanjeController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public KvizPitanjeController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        //public class OdgovoriAddVM
        //{
        //    public bool isCorrect { get; set; }
        //    public int ponudjeniOdgovorId { get; set; }
        //    public int pitanjeId { get; set; }
        //}

        //[HttpPost]
        //public ActionResult SnimiOdgovore([FromBody] OdgovoriAddVM x)
        //{

        //}


        [HttpPost]
        public ActionResult Snimi([FromBody] KvizPitanjeAddVM x)
        {
            KvizPitanje? objekat;
            
            if (x.id == 0)
            {
                objekat = new KvizPitanje();
                _dbContext.Add(objekat);//priprema sql
            }
            else
            {
                objekat = _dbContext.KvizPitanje.Find(x.id);
               
            }

            objekat.id = x.id;
            objekat.kvizId = x.kvizId;
            objekat.pitanjeId=x.pitanjeId;
          


            _dbContext.SaveChanges(); //exceute sql -- update Predmet set ... where...
            return Ok(objekat);
        }

       

        [HttpGet]
        public ActionResult GetAll(int kvizId)
        {
            //var kvpit = _dbContext.KvizPitanje.FirstOrDefault(k => k.kvizId == kvizId);
            //int ponOdgCount = kvpit.Pitanje.ponudjeniOdgovori.Count;
            //var fggg;
            //for (int i = 1; i < 4; i++)
            //{
            //    fggg = _dbContext.KvizPitanje.Where(k => k.kvizId == kvizId).Select(s => new
            //    {
            //        isCorrect = s.Pitanje.ponudjeniOdgovori[i].isCorrect
            //    }).AsQueryable() ;
            //    return Ok(fggg);
            //}

            
            var data = _dbContext.KvizPitanje.Where(k => k.kvizId == kvizId)
                .OrderBy(s => s.id)
                .Select(s => new
                {
                    
                    id = s.id,
                    kvizId = s.kvizId,
                    pitanjeId = s.pitanjeId,
                    tekst = s.Pitanje.tekst,
                    naziv = s.Kviz.naziv,
                    ponudjeniOdgovori = s.Pitanje.ponudjeniOdgovori,
                    isActive=s.Pitanje.isActive,
                    isCorrect1 = s.Pitanje.ponudjeniOdgovori[0].isCorrect,
                    isCorrect2 = s.Pitanje.ponudjeniOdgovori[1].isCorrect,
                    isCorrect3 = s.Pitanje.ponudjeniOdgovori[2].isCorrect,
                    isCorrect4 = s.Pitanje.ponudjeniOdgovori[3].isCorrect,
                    //isCorrect=_dbContext.PonudjeniOdgovor.FirstOrDefault(x=>x.pitanjeId==s.pitanjeId).isCorrect

                }).AsQueryable();
                return Ok(data.Take(100).ToList());
            


        }



        [HttpGet]
        public ActionResult GetBrojPitanja(int kvizId)
        {
         

            int brojPitanja = _dbContext.KvizPitanje.Where(k => k.kvizId == kvizId).Select(x => x.pitanjeId).Count();


           
            return Ok(brojPitanja);


        }
    }
}

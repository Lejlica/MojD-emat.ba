using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Modul1.Models;
using FIT_Api_Example.Modul1.ViewModels;
using FIT_Api_Example.Modul2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Example.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class KorisnikKvizPitanjaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public KorisnikKvizPitanjaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult GenerisiPitanja(int kvizId,int korisnikKvizId)
        {
            KorisnikKvizPitanja? objekat;
            var listaPitanja = _dbContext.KvizPitanje.Where(k => k.kvizId == kvizId).Select(x => x.Pitanje).ToList();

            for (int i = 0; i < listaPitanja.Count; i++)
            {
                    objekat = new KorisnikKvizPitanja();               
                    _dbContext.Add(objekat);
                                            
                    
                    objekat.PitanjeId = listaPitanja[i].id;
                    objekat.KorisnikKvizId = korisnikKvizId;

                    _dbContext.SaveChanges();
               
            }
            return Ok();           
        }

        [HttpGet]
        public ActionResult OdabraniOdgovorGetById(int kvizId, int korisnikKvizPitanjaId)
        {
            string tekst="";
            KorisnikKvizPitanja? objekat=new KorisnikKvizPitanja();
        
            var listaOdabranihOdgovora = _dbContext.KorisnikKvizPitanja.Where(k => k.id == korisnikKvizPitanjaId).Select(k => k.OznaceniOdgovoriIDs).ToList();

            for (int i = 0; i < listaOdabranihOdgovora.Count; i++)
            {
                objekat.OznaceniOdgovoriIDs = listaOdabranihOdgovora[i];
            }

            var listaPitanja = _dbContext.KvizPitanje.Where(k => k.kvizId == kvizId).Select(x => x.Pitanje).ToList();
            var listaOdgovora = _dbContext.KvizPitanje.Where(k => k.kvizId == kvizId).Select(x => x.Pitanje.ponudjeniOdgovori).ToList();
            for (int i = 0; i < listaPitanja.Count; i++)
            {
                for (int j = 0; j < listaOdgovora.Count; j++)
                {
                    if (listaPitanja[i].ponudjeniOdgovori[j].id == objekat.OznaceniOdgovoriIDs.FirstOrDefault())
                        //tekst = listaPitanja[i].ponudjeniOdgovori[j].tekst;
                        objekat.oznaceniOdgTekst= listaPitanja[i].ponudjeniOdgovori[j].tekst;

                }
               
            }

            return Ok(objekat);
        }

        public class SnimiVM
        {
            public class SnimiPitanjaVM
            {
                public int KorisnikKvizPitanjaID { get; set; }
                public List<int> OznaceniOdgovoriIDs { get; set; }
                public int PitanjeId { get; set; } //?

            }
            public int KorisnikKvizId { get; set; }
            public List<SnimiPitanjaVM> Pitanjas { get; set; }
        }


        [HttpPost]
        public ActionResult Snimi([FromBody] SnimiVM x)
        {
            var kviz = _dbContext.KorisnikKviz.SingleOrDefault(k => k.id == x.KorisnikKvizId);
            
           // var pitanja = _dbContext.KorisnikKvizPitanja.Where(p => p.KorisnikKvizId == x.KorisnikKvizId).Select(p => p.PitanjeId);

           

            if (kviz == null)
                return BadRequest();

            foreach(SnimiVM.SnimiPitanjaVM pVM in x.Pitanjas)
            {
                KorisnikKvizPitanja? pEntity = _dbContext.KorisnikKvizPitanja.Find(pVM.KorisnikKvizPitanjaID);
                if (pEntity == null)
                    return BadRequest();

                if (pEntity.KorisnikKvizId != kviz.id)
                    return BadRequest();

                pEntity.OznaceniOdgovoriIDs = pVM.OznaceniOdgovoriIDs;



                //for (int d = 0; d < x.Pitanjas.Count; d++)
                //{
                //    var ponudeniOdgovori = _dbContext.Pitanje.Where(p => p.PitanjeID == x.Pitanjas[d].PitanjeId).Select(p => p.ponudjeniOdgovori).ToList();
                //    for (int i = 0; i < ponudeniOdgovori.Count; i++)
                //    {
                //        for (int j = 0; j < x.Pitanjas.Count; i++)
                //        {
                //            for (int k = 0; k < x.Pitanjas[j].OznaceniOdgovoriIDs.Count; i++)
                //            {
                //                if (x.Pitanjas[j].OznaceniOdgovoriIDs[k] == ponudeniOdgovori[i].Select(p => p.id).FirstOrDefault()
                //                    && ponudeniOdgovori[i].Select(p => p.isCorrect).FirstOrDefault() == true)
                //                    pEntity.ostvareniBodovi += _dbContext.KorisnikKvizPitanja.Where(p => p.PitanjeId == x.Pitanjas[j].PitanjeId).Select(p => p.Pitanje).Sum(p => p.bodovi);

                //            }

                //        }

                //    }
                //}
               
            }

            _dbContext.SaveChanges();
            return Ok();

        }

        [HttpGet]
        public ActionResult GetAll(int korisnikKvizId)
        {
            var pitanja = _dbContext.KorisnikKvizPitanja.Where(s => s.KorisnikKvizId == korisnikKvizId).
                Include(s => s.Pitanje).Include(s => s.Pitanje.ponudjeniOdgovori).ToList();

            var test = _dbContext.KorisnikKviz.Include(s => s.AktivacijaKviza).Include(s => s.korisnikPokrenuo).SingleOrDefault
                (t => t.id == korisnikKvizId);

            return Ok(new
            {
                test,
                pitanja
            });
        }
       
        
    }
}

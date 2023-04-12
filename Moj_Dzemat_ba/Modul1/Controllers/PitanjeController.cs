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
    public class PitanjeController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public PitanjeController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

     
        [HttpPost]
        public ActionResult<Pitanje> Snimi([FromBody] PitanjeAddVM x)
        {
            //if (!HttpContext.GetLoginInfo().isPermisijaModerator)
            //    return Forbid();

          

            Pitanje? objekat;

            if (x.id == 0)
            {
                objekat = new Pitanje();
                _dbContext.Add(objekat);//priprema sql
            }
            else
            {
                objekat = _dbContext.Pitanje.Find(x.id);
            }

            objekat.tekst = x.tekst;
            objekat.isActive = x.isActive;
            


            _dbContext.SaveChanges(); //exceute sql -- update Predmet set ... where...
            return objekat;
        }


        public class IsActivePitanjeVM
        {
            public bool isActive { get; set; }
        }


        [HttpPost]
        public ActionResult SnimiIsActivePitanje(int pitanjeId, [FromBody] IsActivePitanjeVM x)
        {
            Pitanje? objekat=_dbContext.Pitanje.FirstOrDefault(p=>p.id==pitanjeId);

            objekat.isActive = x.isActive;

           _dbContext.SaveChanges(); //exceute sql -- update Predmet set ... where...
            return Ok(objekat);
        }




        [HttpGet]
        public ActionResult GetAll()
        {
            var data = _dbContext.Pitanje
                .OrderByDescending(s => s.id)
                .Select(s => new PitanjeGetVM
                {
                    tekst = s.tekst,
                    isActive = s.isActive
                    
                })
                .AsQueryable();
            return Ok(data.Take(100).ToList());
        }
        [HttpGet]
        public ActionResult GetById()
        {
            var data = _dbContext.Pitanje
                .OrderByDescending(s => s.id)
                .Select(s => new PitanjeGetVM
                {
                    id=s.id,
                    //tekst = s.tekst,
                    //isActive = s.isActive

                })
                .AsQueryable();
            return Ok(data.Take(1).ToList());
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            Pitanje? pitanje = _dbContext.Pitanje.Find(id);

            if (pitanje == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(pitanje);

            _dbContext.SaveChanges();
            return Ok(pitanje);
        }
    }
}

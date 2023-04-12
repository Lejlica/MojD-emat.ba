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
    public class PonudjeniOdgovorController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public PonudjeniOdgovorController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

     
        [HttpPost]
        public ActionResult<PonudjeniOdgovor> Snimi(int pitanjeId,[FromBody] PonudjeniOdgovorAddVM x)
        {
            //if (!HttpContext.GetLoginInfo().isPermisijaModerator)
            //    return Forbid();

            PonudjeniOdgovor? objekat=_dbContext.PonudjeniOdgovor.FirstOrDefault(s=>s.pitanjeId==pitanjeId);

            if (x.id == 0)
            {
                objekat = new PonudjeniOdgovor();
                _dbContext.Add(objekat);//priprema sql
            }
            else
            {
                objekat = _dbContext.PonudjeniOdgovor.Find(x.id);
            }

            objekat.pitanjeId = pitanjeId;
            objekat.tekst = x.tekst;
            objekat.isCorrect = x.isCorrect;
            
            

            _dbContext.SaveChanges(); //exceute sql -- update Predmet set ... where...
            return objekat;
        }

        [HttpGet]
        public ActionResult GetPonOdgById(int pitanjeId)
        {
            var data = _dbContext.PonudjeniOdgovor.Where(p=>p.pitanjeId==pitanjeId && p.isCorrect==true)
                .OrderBy(s => s.tekst)
                .Select(s => new
                {
                    id = s.id,
                    tekst = s.tekst,
                    isCorrect = s.isCorrect,
                    
                })
                .AsQueryable();
            return Ok(data.Take(100).ToList());
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var data = _dbContext.PonudjeniOdgovor
                .OrderBy(s => s.tekst)
                .Select(s => new 
                {
                    id = s.id,
                    tekst = s.tekst,
                    isCorrect=s.isCorrect
                })
                .AsQueryable();
            return Ok(data.Take(100).ToList());
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            PonudjeniOdgovor? podg = _dbContext.PonudjeniOdgovor.Find(id);

            if (podg == null || id == 0)
                return BadRequest("pogresan ID");

            _dbContext.Remove(podg);

            _dbContext.SaveChanges();
            return Ok(podg);
        }
    }
}

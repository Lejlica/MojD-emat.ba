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
    public class MojeVjezbeController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public MojeVjezbeController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

     
        [HttpPost]
        public MojeVjezbe Snimi([FromBody] MojeVjezbeAddVM x)
        {
            MojeVjezbe? objekat;

            if (x.id == 0)
            {
                objekat = new MojeVjezbe();
                _dbContext.Add(objekat);//priprema sql
            }
            else
            {
                objekat = _dbContext.MojeVjezbe.Find(x.id);
            }

            objekat.Id = x.id;
            objekat.IsFinished = x.isFinished;
            objekat.KorisnikId=x.korisnikId;
            objekat.DuhovnaVjezbaId = x.duhovnaVjezbaId;
            
            


            _dbContext.SaveChanges(); //exceute sql -- update Predmet set ... where...
            return objekat;
        }

        [HttpGet]
        public ActionResult GetAll(int? korisnikId)
        {
            var data = _dbContext.MojeVjezbe
                .OrderBy(s => s.Id).Where(s=>s.KorisnikId==korisnikId)
                .Select(s => new MojeVjezbeGetVM
                {
                    id = s.Id,
                    isFinished = s.IsFinished,
                    korisnikId = s.KorisnikId,    
                    duhovnaVjezba = s.DuhovnaVjezba.Naslov,
                    duhovnaVjezbaId=s.DuhovnaVjezbaId
                })
                .Take(100).ToList();
            // order byb skip i take 
            return Ok(data);
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            MojeVjezbe? myVj = _dbContext.MojeVjezbe.Find(id);

            if (myVj == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(myVj);

            _dbContext.SaveChanges();
            return Ok(myVj);
        }
    }
}

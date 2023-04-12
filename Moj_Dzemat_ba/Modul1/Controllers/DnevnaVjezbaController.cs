using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Example.Modul1.ViewModels;
using FIT_Api_Example.Modul2.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Example.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class DnevnaVjezbaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public DnevnaVjezbaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

     
        [HttpPost]
        public ActionResult<DnevnaVjezba> Snimi([FromBody] DnevnaVjezbaAddVM x)
        {
            //if (!HttpContext.GetLoginInfo().isPermisijaImam)
            //    return Forbid();
            DnevnaVjezba? objekat;

            if (x.Id == 0)
            {
                objekat = new DnevnaVjezba();
                _dbContext.Add(objekat);//priprema sql
            }
            else
            {
                objekat = _dbContext.DnevnaVjezba.Find(x.Id);
            }

            objekat.Id = x.Id;
            objekat.Naslov = x.Naslov;
            objekat.Uvod=x.Uvod;
            objekat.Tekst = x.Tekst;
            objekat.DatumObjave = x.DatumObjave;
            objekat.DuhovnaVjezbaId = x.DuhovnaVjezbaId;
            


            _dbContext.SaveChanges(); //exceute sql -- update Predmet set ... where...
            return objekat;
        }

        [HttpGet("{id}")]
        public ActionResult GetByVjezbaId(int id)
        {
            var data = _dbContext.DnevnaVjezba
                .OrderBy(s => s.Id).Where(s=>s.DuhovnaVjezbaId==id)
                .Select(s => new DnevnaVjezba
                {
                    Id=s.Id,
                    Naslov =s.Naslov,
                    Uvod =s.Uvod,    
                    Tekst=s.Tekst,
                    DatumObjave=s.DatumObjave
                    
                    
                })
                .AsQueryable();
            return Ok(data.Take(100).ToList());
        }

        [HttpGet]
        public ActionResult GetById(int? id)
        {
            var data = _dbContext.DnevnaVjezba
                .OrderBy(s => s.Id).Where(s => s.Id == id)
                .Select(s => new DnevnaVjezba
                {
                    Id = s.Id,
                    Naslov = s.Naslov,
                    Uvod = s.Uvod,
                    Tekst = s.Tekst,
                    DatumObjave = s.DatumObjave


                })
                .AsQueryable();
            return Ok(data.Take(100).ToList());
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            DnevnaVjezba? dnVj = _dbContext.DnevnaVjezba.Find(id);

            if (dnVj == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(dnVj);

            _dbContext.SaveChanges();
            return Ok(dnVj);
        }
    }
}

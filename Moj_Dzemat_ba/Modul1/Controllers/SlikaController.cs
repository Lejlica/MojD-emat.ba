using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Modul1.Models;
using FIT_Api_Example.Modul1.ViewModels;
using FIT_Api_Example.Modul2.Models;
using FIT_Api_Examples.Helper;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class SlikaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public SlikaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

     
        [HttpPost]
        public ActionResult Snimi([FromBody] SlikaAddVM x)
        {
            Slika? objekat;

            if (x.id == 0)
            {
                objekat = new Slika();
                _dbContext.Add(objekat);//priprema sql
            }
            else
            {
                objekat = _dbContext.Slika.Find(x.id);
            }

            objekat.Opis = x.opis;
            objekat.ID = x.id;
            objekat.Image = x.image_nova_base64.parseBase64();
            objekat.VijestId = x.VijestId;
            

            _dbContext.SaveChanges(); //exceute sql -- update Predmet set ... where...
            return Ok();
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var data = _dbContext.Slika
                .OrderBy(s => s.ID)
                .Select(s => new 
                {
                    id = s.ID,
                    opis = s.Opis,
                    
                    
                })
                .AsQueryable();
            return Ok(data.Take(100).ToList());
        }


        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            Slika? pitanje = _dbContext.Slika.Find(id);

            if (pitanje == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(pitanje);

            _dbContext.SaveChanges();
            return Ok(pitanje);
        }

        

    }
}

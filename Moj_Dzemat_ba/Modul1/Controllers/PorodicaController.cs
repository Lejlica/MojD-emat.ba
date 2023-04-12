using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Modul1.ViewModels;
using FIT_Api_Example.Modul2.Models;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class PorodicaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public PorodicaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

     
        [HttpPost]
        public ActionResult Add([FromBody] PorodicaAddVM x)
        {
            Porodica? porodica;

            if (x.id == 0)
            {
                porodica = new Porodica();
                _dbContext.Add(porodica);
            }
            else
            {
                porodica = _dbContext.Porodica.Find(x.id);
            };

            porodica.Prezime = x.prezime;
            porodica.NosiocPorodice = x.nosiocPorodice;
            porodica.Lokacija = x.lokacija;
            porodica.BrojTelefona = x.brojTelefona;
            porodica.Id = x.id;
            porodica.Adresa = x.adresa;
            porodica.ClanoviHarema = x.clanoviHarema;
            porodica.ClanoviIZ = x.clanoviIZ;
            porodica.dzematId = x.dzematId;        
            
            _dbContext.SaveChanges();
            return Ok();
            
        }

        [HttpGet]
        public ActionResult GetAll(int? id)
        {
            var data = _dbContext.Porodica
                .OrderBy(s => s.Prezime).Where(s => s.Id == id || id == null)
                .Select(s => new PorodicaGetVM
                {
                    lokacija=s.Lokacija,
                    prezime = s.Prezime,
                    nosiocPorodice= s.NosiocPorodice,
                    telefon=s.BrojTelefona,
                    clanoviHarema = s.ClanoviHarema,
                    clanoviIZ = s.ClanoviIZ,
                    id=s.Id
                })
                .AsQueryable();
            return Ok(data.Take(100).ToList());
        }


        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            Porodica? porodica = _dbContext.Porodica.Find(id);

            if (porodica == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(porodica);

            _dbContext.SaveChanges();
            return Ok(porodica);
        }
    }
}

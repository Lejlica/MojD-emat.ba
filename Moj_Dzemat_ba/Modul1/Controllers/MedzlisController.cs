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
    public class MedzlisController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public MedzlisController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpPost]
        public ActionResult Snimi(int medzlis_id, [FromBody] MedzlisAddVM x)
        {
            Medzlis? objekat;

            if (medzlis_id == 0)
            {
                objekat = new Medzlis();
                _dbContext.Add(objekat);//priprema sql
            }
            else
            {
                objekat = _dbContext.Medzlis.FirstOrDefault(m => m.Id == medzlis_id);
            }


            objekat.Naziv = x.naziv;
            objekat.Adresa = x.adresa;
            objekat.Fax = x.fax;
            objekat.Telefon = x.telefon;
            objekat.Informacije = x.informacije;
            objekat.MuftijstvoId = x.MuftijstvoId;

            _dbContext.SaveChanges(); //exceute sql -- update Predmet set ... where...
            return Ok(objekat);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var data = _dbContext.Medzlis
                .OrderBy(s => s.Id)
                .Select(s => new
                {
                    id = s.Id,
                    naziv = s.Naziv,
                    adresa = s.Adresa,
                    informacije = s.Informacije,
                    fax = s.Fax,
                    telefon = s.Telefon,
                    muftijstvo = s.Muftijstvo.Naziv,
                    muftijstvoId = s.Muftijstvo.Id

                })
                .AsQueryable();
            return Ok(data.Take(100).ToList());
        }


        [HttpPost()]
        public ActionResult Delete(int id)
        {
            Medzlis? medzils = _dbContext.Medzlis.Find(id);

            if (medzils == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(medzils);

            _dbContext.SaveChanges();
            return Ok();
        }
    }
}

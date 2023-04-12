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
    public class MuftijstvoController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public MuftijstvoController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpPost]
        public ActionResult Snimi(int muftijstvo_id, [FromBody] MuftijstvoAddVM x)
        {

            Muftijstvo? objekat;

            if (muftijstvo_id == 0)
            {
                objekat = new Muftijstvo();
                _dbContext.Add(objekat);//priprema sql
            }
            else
            {
                objekat = _dbContext.Muftijstvo.FirstOrDefault(m => m.Id == muftijstvo_id);
            }


            objekat.Naziv = x.naziv;
            objekat.Adresa = x.adresa;
            objekat.Fax = x.fax;
            objekat.Telefon = x.telefon;
            objekat.Informacije = x.informacije;
            objekat.KontaktOsoba = x.kontaktOsoba;

            _dbContext.SaveChanges(); //exceute sql -- update Predmet set ... where...
            return Ok(objekat);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var data = _dbContext.Muftijstvo
                .OrderBy(s => s.Id)
                .Select(s => new 
                {
                    id = s.Id,
                    naziv = s.Naziv,
                    adresa = s.Adresa,
                    informacije = s.Informacije,
                    fax = s.Fax,
                    telefon = s.Telefon,
                    kontaktOsoba = s.KontaktOsoba

                })
                .AsQueryable();
            return Ok(data.Take(100).ToList());
        }


        [HttpPost()]
        public ActionResult Delete(int id)
        {
            Muftijstvo muftijstvo = _dbContext.Muftijstvo.Find(id);

            if (muftijstvo == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(muftijstvo);

            _dbContext.SaveChanges();
            return Ok();
        }
    }
}

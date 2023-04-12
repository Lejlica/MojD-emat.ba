using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Example.Modul1.ViewModels;
using FIT_Api_Example.Modul2.Models;
using FIT_Api_Examples.Helper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Example.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class DzematController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public DzematController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

     
        [HttpPost]
        public ActionResult<Dzemat> Snimi([FromBody] DzematAddVM x)
        {

            Dzemat? objekat;

            if (x.id == 0)
            {
                objekat = new Dzemat();
                _dbContext.Add(objekat);//priprema sql
            }
            else
            {
                objekat = _dbContext.Dzemat.Find(x.id);
            }

            objekat.Id = x.id;
            objekat.Naziv = x.naziv;
            objekat.LokacijaDzamije=x.lokacijaDzamije;
            objekat.Informacije = x.info;
            objekat.MedzlisId = x.MedzlisId;
            objekat.KratkiOpis = x.kratkiOpis;
            objekat.DzematskiOdbor = x.dzematskiOdbor;

            //_dbContext.SaveChanges(); //exceute sql -- update Predmet set ... where...
            if (!string.IsNullOrEmpty(x.slika_nova_base64))

            {
                byte[] bajtovi_slike = x.slika_nova_base64.parseBase64();

                objekat.slika_dzemata_bytes = bajtovi_slike;

            }

            _dbContext.SaveChanges();
            return objekat;
        }

        [HttpGet]
        public ActionResult GetAll(int? dzematId)
        {
            var data = _dbContext.Dzemat
                .OrderBy(s => s.Naziv).Where(s=>s.Id==dzematId || dzematId==null)
                .Select(s => new DzematGetVM
                {
                    id=s.Id,
                    naziv = s.Naziv,
                    lokacijaDzamije = s.LokacijaDzamije,
                    informacije = s.Informacije,
                    medzlis=s.Medzlis.Naziv,
                    kratkiOpis=s.KratkiOpis,
                    dzematskiOdbor=s.DzematskiOdbor
    
                })
                .AsQueryable();
            return Ok(data.Take(100).ToList());
        }

        [HttpGet("{dzematid}")]
        public ActionResult GetSlikaKorisnika(int dzematid)
        {

            byte[] bajtovi = _dbContext.Dzemat.Find(dzematid).slika_dzemata_bytes;

            if (bajtovi == null)
            {
                bajtovi = Fajlovi.Ucitaj(Config.SlikeFolder + "empty.png");
            }

            return File(bajtovi, "image/png");
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            Dzemat? dzemat = _dbContext.Dzemat.Find(id);

            if (dzemat == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(dzemat);

            _dbContext.SaveChanges();
            return Ok(dzemat);
        }
    }
}

using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Example.Modul1.ViewModels;
using FIT_Api_Example.Modul2.Models;
using FIT_Api_Examples.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Example.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class DuhovnaVjezbaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public DuhovnaVjezbaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

     
        [HttpPost]
        public ActionResult Snimi([FromBody] DuhovnaVjezbaGetAllVM x)
        {
            DuhovnaVjezba? objekat;

            if (x.id == 0)
            {
                objekat = new DuhovnaVjezba()
                {
                   DatumPocetka=DateTime.Now,

                };
                _dbContext.Add(objekat);//priprema sql
            }
            else
            {
                objekat = _dbContext.DuhovnaVjezba.FirstOrDefault(s => s.Id == x.id);
            }

            objekat.Id = x.id;
            objekat.Naslov = x.naslov;
            objekat.Opis=x.opis;
            objekat.Tekst = x.tekst;
            objekat.IsActive = x.isActive ;
            objekat.DatumZavrsetka=x.datumZavrsetka;
            objekat.ModeratorId = x.moderatorId;

            //_dbContext.SaveChanges();

            if (!string.IsNullOrEmpty(x.slika_nova_base64))

            {
                byte[] bajtovi_slike = x.slika_nova_base64.parseBase64();

                objekat.slika_korisnika_bytes = bajtovi_slike;

            }

            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpGet]
        [Autorizacija(moderator: true, imam: true, korisnik: true, admin: true)]
        public ActionResult GetAll(int? vjezbaId)
        {
            var data = _dbContext.DuhovnaVjezba
                .OrderBy(s => s.Id).Where(s => s.Id == vjezbaId || vjezbaId == null)
                .Select(s => new 
                {
                    id = s.Id,
                    isActive = s.IsActive,
                    datumPocetka = s.DatumPocetka.ToString("dd.MM.yyyy"),
                    datumZavrsetka = s.DatumZavrsetka.ToString("dd.MM.yyyy"),
                    naslov = s.Naslov,
                    opis = s.Opis,
                    moderatorId = s.ModeratorId,
                    tekst = s.Tekst,
                    trajanje = (s.DatumZavrsetka - s.DatumPocetka).Days
                })
                .AsQueryable();
            return Ok(data.Take(100).ToList());
        }

        [HttpGet("{vjezbaid}")]
        public ActionResult GetSlikaKorisnika(int vjezbaid)
        {
            //if (!HttpContext.GetLoginInfo().isLogiran)
            //    return BadRequest("nije logiran");

            byte[] bajtovi = _dbContext.DuhovnaVjezba.Find(vjezbaid).slika_korisnika_bytes;

            if (bajtovi == null)
            {
                bajtovi = Fajlovi.Ucitaj(Config.SlikeFolder + "empty.png");
            }

            return File(bajtovi, "image/png");
        }


        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            DuhovnaVjezba? akt = _dbContext.DuhovnaVjezba.Find(id);

            if (akt == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(akt);

            _dbContext.SaveChanges();
            return Ok(akt);

        }
        [HttpGet("{id}")]
        public ActionResult Delete1(int id)
        {
            DuhovnaVjezba? akt = _dbContext.DuhovnaVjezba.Find(id);

            if (akt == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(akt);

            _dbContext.SaveChanges();
            return Ok(akt);

        }

    }
  

}


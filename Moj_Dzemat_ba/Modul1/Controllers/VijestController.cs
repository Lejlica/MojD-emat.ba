using Azure.Security.KeyVault.Certificates;
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
    public class VijestController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public VijestController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpPost]
        [Autorizacija(moderator: false, imam: true, korisnik: false,admin:true)]
        public ActionResult Snimi(int vijest_id,[FromBody] VijestAddVM x)
        {
            Vijest objekat;

            if (vijest_id == 0)
            {
                objekat = new Vijest();
                _dbContext.Add(objekat);//priprema sql
            }
            else
            {
                objekat = _dbContext.Vijest.FirstOrDefault(v => v.Id == vijest_id);
                if (objekat == null)
                    return BadRequest("pogresan ID");
            }



            objekat.Naslov = x.naslov;
            objekat.Tekst = x.tekst;
            objekat.Datum = x.datum;
            objekat.ImamId = HttpContext.GetLoginInfo().korisnickiNalog.id;
            objekat.Autor = HttpContext.GetLoginInfo().korisnickiNalog.korisnickoIme;
            objekat.Opis = x.opis;


            if (!string.IsNullOrEmpty(x.image_nova_base64))

            {
                byte[] bajtovi_slike = x.image_nova_base64.parseBase64();

                objekat.slika_bajtovi = bajtovi_slike;

            }

            _dbContext.SaveChanges(); //exceute sql -- update Predmet set ... where...
            return Ok(objekat);
        }

        [HttpGet]
        [Autorizacija(moderator: true, imam: true, korisnik: true, admin: true)]
        public ActionResult GetAll1()

        {
            var data = _dbContext.Vijest
                .OrderByDescending(s => s.Id)
                .Select(s => new
                {
                    id = s.Id,
                    naslov = s.Naslov,
                    tekst = s.Tekst,
                    datum = s.Datum,
                    opis = s.Opis,
                    autor = s.Autor
                });
            return Ok(data);
        }

        [HttpGet]
        [Autorizacija(moderator: true, imam: true, korisnik: true, admin: true)]
        public ActionResult GetAll(int pageNumber = 1, int pageSize = 5)

        {
            IQueryable<VijestGetVM> data = _dbContext.Vijest
                .OrderByDescending(s => s.Id)
                .Select(s => new VijestGetVM
                {
                    id = s.Id,
                    naslov = s.Naslov,
                    tekst = s.Tekst,
                    datum = s.Datum,
                    opis = s.Opis,
                    autor = s.Autor
                });
            return Ok(PagedList<VijestGetVM>.Create(data, pageNumber, pageSize));
        }

        [HttpPost("{id}")]
        
        public ActionResult Delete(int id)
        {
            Vijest? vijest = _dbContext.Vijest.Find(id);

            if (vijest == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(vijest);

            _dbContext.SaveChanges();
            return Ok(vijest);
        }
        [HttpGet]
        public ActionResult GetById(int vijestId)
        {
            var data = _dbContext.Vijest.Where(v => v.Id == vijestId)

                .Select(s => new VijestAddVM
                {
                    id = s.Id,
                    naslov = s.Naslov,
                    tekst = s.Tekst,
                    datum = s.Datum,
                    opis=s.Opis

                })
                .ToList();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public ActionResult GetSlika(int id)
        {

            byte[] bajtovi_slike = _dbContext.Vijest.Find(id).slika_bajtovi;
            if (bajtovi_slike == null)
            {
                bajtovi_slike = Fajlovi.Ucitaj("wwwroot/profile_images/empty.png");
            }
            return File(bajtovi_slike, "image/png");
        }
    }
}

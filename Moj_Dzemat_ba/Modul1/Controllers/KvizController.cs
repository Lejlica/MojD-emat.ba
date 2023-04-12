using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Example.Modul1.ViewModels;
using FIT_Api_Example.Modul2.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using FIT_Api_Example.Modul1.Models;
using System.Linq;
using System.IO.Pipes;

namespace FIT_Api_Example.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class KvizController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public KvizController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

     
        [HttpPost]
        [Autorizacija(moderator: false, imam: true, korisnik: false, admin: true)]
        public ActionResult<Kviz> Snimi([FromBody] KvizAddVM x)
        {
            //if (!HttpContext.GetLoginInfo().isPermisijaModerator)
            //    return BadRequest("nije logiran");

            Kviz? objekat;

            if (x.id == 0)
            {
                objekat = new Kviz();
                _dbContext.Add(objekat);//priprema sql
            }
            else
            {
                objekat = _dbContext.Kviz.Find(x.id);
            }

            objekat.id = x.id;
            objekat.naziv = x.naziv;
            objekat.vrstaKviza=x.vrstaKviza;
            objekat.datumKviza = x.datumKviza;
            objekat.brojPitanja = x.brojPitanja;
            objekat.moderator_Id = x.moderatorId;
            objekat.opis = x.opis;

            _dbContext.SaveChanges(); //exceute sql -- update Predmet set ... where...
            return objekat;
        }

        //[HttpGet]
        //[Autorizacija(moderator: true, imam: false, korisnik: true, admin: true)]
        //public ActionResult GetAll1()
        //{
        //    // IQueryable data = Enumerable.Empty<KvizGetVM>().AsQueryable();
        //    IQueryable<KvizGetVM> data;
        //    var listaAktivacija = _dbContext.AktivacijaKviza.ToList();
        //    for (int i = 0; i < listaAktivacija.Count; i++)
        //    {

        //        data = _dbContext.Kviz.Where(s => s.id == listaAktivacija[i].KvizId)
        //      .Select(s => new KvizGetVM
        //      {
        //          id = s.id,
        //          naziv = s.naziv,
        //          vrstaKviza = s.vrstaKviza,
        //          datumKviza = s.datumKviza,
        //          brojPitanja = s.brojPitanja,
        //          opis = s.opis
        //      });
               

        //    }
        //    return Ok(data);


        //}

        [HttpGet]
        [Autorizacija(moderator: false, imam: true, korisnik: false, admin: true)]
        public ActionResult GetAll()
        {

            var data = _dbContext.Kviz
            .OrderByDescending(s => s.id)
            .Select(s => new KvizGetVM
            {
                id = s.id,
                naziv = s.naziv,
                vrstaKviza = s.vrstaKviza,
                datumKviza = s.datumKviza,
                brojPitanja = s.brojPitanja,
                opis = s.opis
            })
            .AsQueryable();
            return Ok(data.Take(100).ToList());



        }

        [HttpPost("{id}")]
        [Autorizacija(moderator: false, imam: true, korisnik: false, admin: true)]
        public ActionResult Delete(int id)
        {
            Kviz? kviz = _dbContext.Kviz.Find(id);

            if (kviz == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(kviz);

            _dbContext.SaveChanges();
            return Ok(kviz);
        }
    }
}

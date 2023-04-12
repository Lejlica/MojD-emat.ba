using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Example.Modul1.ViewModels;
using FIT_Api_Example.Modul2.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FIT_Api_Example.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class ModeratorController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ModeratorController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet("{guid}")]
        public ActionResult Aktivacija(string guid)
        {
            var moderator = _dbContext.Moderator.FirstOrDefault(m => m.aktivacijaGUID == guid);
            if (moderator != null)
            {
                moderator.isAktiviran = true;
                _dbContext.SaveChanges();
                return Redirect("http://localhost:4200/vijesti");
            }
            return BadRequest("pogresan URL");
        }

        [HttpPost]
        [Autorizacija(moderator: false, imam: false, korisnik: false, admin: true)]
        public ActionResult Add([FromBody] ModeratorAddVM x)
        {
            Moderator? moderator;

            if (x.id == 0)
            {
                moderator = new Moderator();
                _dbContext.Add(moderator);//priprema sql

                moderator.aktivacijaGUID = Guid.NewGuid().ToString();
            }
            else
            {
                moderator = _dbContext.Moderator.Find(x.id);
            }

            moderator.id = x.id;
            moderator.Ime = x.ime;
            moderator.Prezime = x.prezime;
            moderator.email = x.email;
            moderator.korisnickoIme = x.korisnickoIme;        
            moderator.Telefon = x.telefon;
            moderator.lozinka = x.lozinka;
          


            _dbContext.SaveChanges(); //exceute sql -- update Predmet set ... where...

           EmailLog.noviModerator(moderator, HttpContext);
            return Ok();
        }
        public class ModeratorAddVM2
        {
            public string ime { get; set; }
            public string prezime { get; set; }
            public string email { get; set; }
            public string telefon { get; set; }

        }
        [HttpPost]
        public Moderator SnimiProfPostav(int id,[FromBody] ModeratorAddVM2 x)
        {
            Moderator? objekat;


            objekat = _dbContext.Moderator.Find(id);

            
            objekat.Ime = x.ime;
            objekat.Prezime = x.prezime;
            objekat.email = x.email; 
            objekat.Telefon = x.telefon;
            


            _dbContext.SaveChanges(); //exceute sql -- update Predmet set ... where...
            return objekat;
        }
        [HttpGet]
        public ActionResult GetById(int id)
        {
          
            var data = _dbContext.Moderator.Where(k => k.id == id)

                .Select(s => new
                {
                 
                    ime = s.Ime,
                    prezime = s.Prezime,
                    email = s.email,
                    telefon = s.Telefon
                })
                .SingleOrDefault();
            return Ok(data);
        }
        [HttpGet]
        public ActionResult GetAll(int? id)
        {
            var data = _dbContext.Moderator
                .OrderBy(s => s.Prezime)
                .Select(s => new
                {
                    id=s.id,
                    ime=s.Ime,
                    telefon = s.Telefon,
                    prezime = s.Prezime,
                    email = s.email,
                   
                   


                })
                .AsQueryable();
            return Ok(data.Take(100).ToList());
        }


        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            Moderator? moderator = _dbContext.Moderator.Find(id);

            if (moderator == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(moderator);

            _dbContext.SaveChanges();
            return Ok(moderator);
        }
    }
}

using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
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
    public class ImamController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ImamController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

     
        [HttpPost]
        public Imam Snimi([FromBody] ImamAddVM x)
        {
            Imam? objekat;

            if (x.id == 0)
            {
                objekat = new Imam();
                _dbContext.Add(objekat);//priprema sql
            }
            else
            {
                objekat = _dbContext.Imam.Find(x.id);
            }

            objekat.id = x.id;
            objekat.Ime = x.ime;
            objekat.Prezime=x.prezime;
            objekat.email = x.email;
            objekat.korisnickoIme = x.username;
            objekat.DatumRodjenja = x.datumRodjenja;
            objekat.Telefon = x.telefon;
            objekat.dzematId=x.dzematId;
            objekat.lozinka = x.password;
            objekat.Salt = x.salt;
            objekat.Fakultet = x.fakultet;
            objekat.Biografija = x.biografija;         // _dbContext.SaveChanges();

            //if (!string.IsNullOrEmpty(x.slika_nova_base64))

            //{
            //    byte[] bajtovi_slike = x.slika_nova_base64.parseBase64();

            //    objekat.slika_imama_bytes = bajtovi_slike;

            //}

            _dbContext.SaveChanges();
            return objekat;
        }
        public class ImamAddVM2
        {
            public string ime { get; set; }
            public string prezime { get; set; }
            public string email { get; set; }
            public string telefon { get; set; }

        }

        [HttpPost]
        public Imam SnimiProfPostav(int id, [FromBody] ImamAddVM2 x)
        {
            Imam? objekat;


            objekat = _dbContext.Imam.Find(id);


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
            
            var data = _dbContext.Imam.Where(k => k.id == id)

                .Select(s => new
                {
                   
                    ime = s.Ime,
                    prezime = s.Prezime,
                    email = s.email,
                    
                    telefon = s.Telefon,
                   

                })
                .SingleOrDefault();
            return Ok(data);
        }

        [HttpGet]
        public ActionResult GetAll(int? dzematId)
        {
            var data = _dbContext.Imam
                .OrderBy(s => s.Prezime).Where(s=>s.dzematId==dzematId || dzematId==null)
                .Select(s => new 
                {
                    id=s.id,
                    ime = s.Ime,
                    prezime = s.Prezime,
                    email=s.email,
                    dzemat=s.dzemat.Naziv,
                    biografija = s.Biografija,
                    telefon=s.Telefon
                })
                .AsQueryable();
            return Ok(data.Take(100).ToList());
        }

        //[HttpGet("{imamid}")]
        //public ActionResult GetSlikaImama(int imamid)
        //{

        //    byte[] bajtovi = _dbContext.Imam.Find(imamid).slika_imama_bytes;

        //    if (bajtovi == null)
        //    {
        //        bajtovi = Fajlovi.Ucitaj(Config.SlikeFolder + "empty.png");
        //    }

        //    return File(bajtovi, "image/png");
        //}

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            Imam? imam = _dbContext.Imam.Find(id);

            if (imam == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(imam);

            _dbContext.SaveChanges();
            return Ok(imam);
        }
    }
}

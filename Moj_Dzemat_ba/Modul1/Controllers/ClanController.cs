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
    public class ClanController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ClanController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

     
        [HttpPost]
        public ActionResult Add([FromBody] ClanAddVM x)
        {
            Clan clan;

            if (x.id == 0)
            {
                clan = new Clan();
                _dbContext.Add(clan);
            }
            else
            {
                clan = _dbContext.Clan.Find(x.id);
            };

            clan.Id = x.id;
            clan.Ime = x.ime;
            clan.Prezime = x.prezime;
            clan.OdnosSaNosiocem = x.odnosSaNosiocem;
            clan.DatumRodjenja = x.datumrodjenja;
            clan.PorodicaID = x.porodicaId;
            clan.Status = x.status;
            clan.Napomena = x.napomena;
            clan.Mekteb = x.mekteb;
            
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public ActionResult GetAll(int? id)
        {
            var data = _dbContext.Clan
                .OrderBy(s => s.DatumRodjenja).Where(s=>s.PorodicaID==id || id==null)
                .Select(s => new ClanGetVM
                {
                    id=s.Id,
                    ime=s.Ime,
                    odnosSaNosiocem = s.OdnosSaNosiocem,
                    prezime = s.Prezime,
                    datumrodjenja = s.DatumRodjenja.ToString("dd.MM.yyyy"),
                    status = s.Status,
                    nosioc=s.Porodica.NosiocPorodice,
                    porodicaId=s.PorodicaID,
                    mekteb= (bool)s.Mekteb

                })
                .AsQueryable();
            return Ok(data.Take(100).ToList());
        }


        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            Clan? clanPorodice = _dbContext.Clan.Find(id);

            if (clanPorodice == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(clanPorodice);

            _dbContext.SaveChanges();
            return Ok(clanPorodice);
        }
    }
}

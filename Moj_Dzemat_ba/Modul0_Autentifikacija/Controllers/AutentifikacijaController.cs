using Azure.Core;
using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Modul0_Autentifikacija.Models;
using FIT_Api_Example.Modul0_Autentifikacija.ViewModels;
using FIT_Api_Examples.Helper;
using Microsoft.AspNetCore.Mvc;
using static FIT_Api_Example.Helper.AutentifikacijaAutorizacija.MyAuthTokenExtension;

namespace FIT_Api_Example.Modul0_Autentifikacija.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")] 
    public class AutentifikacijaController:ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public AutentifikacijaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpPost]
        public ActionResult<LoginInformacije> Login([FromBody] LoginVM x)
        {
            //1- provjera logina
            KorisnickiNalog? logiraniKorisnik = _dbContext.KorisnickiNalog
                .FirstOrDefault(k =>
                k.korisnickoIme != null && k.korisnickoIme == x.korisnickoIme && k.lozinka == x.lozinka);

            if (logiraniKorisnik == null)
            {
                //pogresan username i password
                return new LoginInformacije(null);
            }

            //2- generisati random string
            string randomString = TokenGenerator.Generate(10);
            string twoFcode = TokenGenerator.Generate(4);

            //3- dodati novi zapis u tabelu AutentifikacijaToken za logiraniKorisnikId i randomString
            var noviToken = new AutentifikacijaToken()
            {
                ipAdresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString(),
                vrijednost = randomString,
                korisnickiNalog = logiraniKorisnik,
                vrijemeEvidentiranja = DateTime.Now,
                twoFcode = twoFcode
            };

            _dbContext.Add(noviToken);
            _dbContext.SaveChanges();

            EmailLog.UspjesnoLogiranKorisnik(noviToken, Request.HttpContext);

            //4- vratiti token string
            return new LoginInformacije(noviToken);
        }
        [HttpGet("{code}")]
        public ActionResult OtkljucajTwoF(string code)
        {
            var korisnickinalog = HttpContext.GetLoginInfo().korisnickiNalog;
            if (korisnickinalog == null)
            {
                return BadRequest("korisnik nije logiran");
            }

            var token = _dbContext.AutentifikacijaToken.FirstOrDefault(t => t.twoFcode == code && t.KorisnickiNalogId == korisnickinalog.id);
            if (token != null)
            {
                token.twoFcodeJelOtkljucan = true;

                _dbContext.SaveChanges();
                return Ok();
            }

            return BadRequest("pogresan URL");
        }

        [HttpPost]
        public ActionResult Logout()
        {
            AutentifikacijaToken autentifikacijaToken = HttpContext.GetAuthToken();

            if (autentifikacijaToken == null)
                return Ok();

            _dbContext.Remove(autentifikacijaToken);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public ActionResult<AutentifikacijaToken> Get()
        {
            AutentifikacijaToken autentifikacijaToken = HttpContext.GetAuthToken();

            return autentifikacijaToken;
        }
    }
}


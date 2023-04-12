using FIT_Api_Example.Modul0_Autentifikacija.Models;
using FIT_Api_Example.Modul2.Models;

namespace FIT_Api_Example.Helper
{
    public class EmailLog
    {
        public static void UspjesnoLogiranKorisnik(AutentifikacijaToken token, HttpContext httpContext)
        {
            var logiraniKorisnik = token.korisnickiNalog;
            if (logiraniKorisnik.isAdmin)
            {
                var poruka = $"Postovani/a {logiraniKorisnik.korisnickoIme}, <br> " +
                    $"Code za pristup vašem nalogu je {token.twoFcode} <br>" +
                    $"Login info: {DateTime.Now}";
                EmailSender.Posalji(logiraniKorisnik.email, "Code za pristup ", poruka, true);
            }
        }



        public static void noviModerator(Moderator moderator, HttpContext httpContext)
        {
            //if (!moderator.isAktiviran)
            //{
            //    string url = "https://localhost:7008/moderator/Aktivacija/" + moderator.aktivacijaGUID;
            //    string poruka = $"Postovani/a {moderator.Ime}, <br> Link za aktivaciju <a href='{url}'>{url}</a>...{DateTime.Now}";
            //    EmailSender.Posalji(moderator.email, "Aktivacija korisnika", poruka, true);
            //}
            if (!moderator.isAktiviran)
            {
                var Request = httpContext.Request;
                var location = $"{Request.Scheme}://{Request.Host}";

                string url = location + "/moderator/Aktivacija/" + moderator.aktivacijaGUID;
                //string url = "https://localhost:7008/moderator/Aktivacija/" + moderator.aktivacijaGUID;
                string poruka = $"Postovani/a {moderator.Ime}, <br> Link za aktivaciju <a href='{url}'>{url}</a>...{DateTime.Now}";
                EmailSender.Posalji(moderator.email, "Aktivacija korisnika", poruka, true);
            }

        }
    }
}

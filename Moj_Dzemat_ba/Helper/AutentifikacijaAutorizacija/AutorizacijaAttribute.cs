using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Helper.AutentifikacijaAutorizacija
{
    public class AutorizacijaAttribute : TypeFilterAttribute
    {
       public AutorizacijaAttribute(bool moderator, bool imam, bool korisnik,bool admin)
                : base(typeof(MyAuthorizeImpl))
       {
             Arguments = new object[] { moderator,imam,korisnik,admin};
       }
        
    }

        public class MyAuthorizeImpl : IActionFilter
        {
            private readonly bool _imam;
            private readonly bool _moderator;
            private readonly bool _korisnik;
            private readonly bool _admin;


            public MyAuthorizeImpl(bool moderator, bool imam, bool korisnik,bool admin)
            {
                _imam = imam;
                _moderator = moderator;
                _korisnik = korisnik;
                _admin = admin;
                
            }
            public void OnActionExecuted(ActionExecutedContext filterContext)
            {
                 KretanjePoSistemu.Save(filterContext.HttpContext);

            }

            public void OnActionExecuting(ActionExecutingContext filterContext)
            {
                MyAuthTokenExtension.LoginInformacije loginInfo = filterContext.HttpContext.GetLoginInfo();

                if (!loginInfo.isLogiran || loginInfo.korisnickiNalog==null)
                {
                    filterContext.Result = new UnauthorizedResult();
                    return;
                }

                if (!loginInfo.korisnickiNalog.isAktiviran && !loginInfo.korisnickiNalog.isKorisnik && !loginInfo.korisnickiNalog.isImam)
                {
                    filterContext.Result = new UnauthorizedObjectResult("Korisnik nije aktiviran, provjerite vas email" + loginInfo.korisnickiNalog.email);
                    return;
                }


                if (loginInfo.korisnickiNalog.isAdmin && _admin)
                {
                if (loginInfo.autentifikacijaToken == null || !loginInfo.autentifikacijaToken.twoFcodeJelOtkljucan)
                {
                    filterContext.Result = new UnauthorizedObjectResult("Potrebno je otkljucati login sa kodom poslanim na vaš email" + loginInfo.korisnickiNalog.email);
                    return;
                }
                return;
                }
            
                if (loginInfo.korisnickiNalog.isImam && _imam)
                {
                    return;//ok - ima pravo pristupa
                }
            
                if (loginInfo.korisnickiNalog.isModerator && _moderator)
                {
                    //if (loginInfo.autentifikacijaToken == null || !loginInfo.autentifikacijaToken.twoFcodeJelOtkljucan)
                    //{
                    //    filterContext.Result = new UnauthorizedObjectResult("Potrebno je otkljucati login sa kodom poslanim na vaš email" + loginInfo.korisnickiNalog.email);
                    //    return;
                    //}
                    return;
                }

                if (loginInfo.korisnickiNalog.isKorisnik && _korisnik)
                {
                    return;//ok - ima pravo pristupa
                }

                //else nema pravo pristupa
                filterContext.Result = new UnauthorizedResult();
            }
        }
    
}


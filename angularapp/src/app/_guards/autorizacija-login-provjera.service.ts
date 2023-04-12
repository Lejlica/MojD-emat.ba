import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";


@Injectable()
export class AutorizacijaLoginProvjera implements CanActivate {

    constructor(private router: Router) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

      try {
        //nedovrseno privremeno rjesenje
        if (AutentifikacijaHelper.getLoginInfo().isLogiran)
        {
          let isAktiviran=AutentifikacijaHelper.getLoginInfo().autentifikacijaToken?.korisnickiNalog?.isAktiviran;
          if(!isAktiviran && !AutentifikacijaHelper.getLoginInfo().autentifikacijaToken?.korisnickiNalog?.isKorisnik && !AutentifikacijaHelper.getLoginInfo().autentifikacijaToken?.korisnickiNalog?.isImam)
          {
            this.router.navigate(['/not-found']);
            return  false;
          }

          return true;
        }

      }catch (e) {
      }
      // not logged in so redirect to login page with the return url
      this.router.navigate(['login'], { queryParams: { returnUrl: state.url }});
      return false;
    }
}

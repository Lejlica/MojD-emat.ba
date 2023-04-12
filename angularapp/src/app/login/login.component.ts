import { Component, OnInit } from '@angular/core';
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";
import {LoginInformacije} from "../_helpers/login-informacije";

declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  txtLozinka: any;
  txtKorisnickoIme: any;

  constructor(private httpKlijent: HttpClient, private router: Router) {
  }

  ngOnInit(): void {
  }

  btnLogin() {
    let saljemo = {
      korisnickoIme:this.txtKorisnickoIme,
      lozinka: this.txtLozinka
    };
    this.httpKlijent.post<LoginInformacije>(MojConfig.adresa_servera+ "/Autentifikacija/Login/", saljemo)
      .subscribe((x:LoginInformacije) =>{
        if (x.isLogiran) {
porukaSuccess("Uspješan login!")
          AutentifikacijaHelper.setLoginInfo(x)

          if(x.autentifikacijaToken?.korisnickiNalog.isAdmin /*|| x.autentifikacijaToken?.korisnickiNalog.isModerator*/)
            this.router.navigateByUrl("/two-f-otkljucaj");
          else {
            if(AutentifikacijaHelper.getLoginInfo().autentifikacijaToken?.korisnickiNalog?.isImam)
              this.router.navigateByUrl("/vijesti-imam-permisije");
            else
              this.router.navigateByUrl("/vijesti");
          }
        }
        else
        {
          AutentifikacijaHelper.setLoginInfo(null)
porukaError("Neispravna lozinka ili korisničko ime!")
        }
      });
  }


}

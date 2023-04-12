import { Component, OnInit } from '@angular/core';
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {NovaRegistracijaVM} from "./NovaRegistracijaVM";
import {DzematVM} from "./DzematVM";
import {LoginInformacije} from "../_helpers/login-informacije";
declare function porukaSuccess(a: string):any;
@Component({
  selector: 'app-registracija',
  templateUrl: './registracija.component.html',
  styleUrls: ['./registracija.component.css']
})
export class RegistracijaComponent implements OnInit {

  novaRegistracija:NovaRegistracijaVM;
  dzematPodaci: any;

  constructor(private httpKlijent: HttpClient, private router: Router) {}

  ngOnInit(): void {
    this.getDzemati();
    this.BtnNovaRegistracija();
  }

  RegistrujSe() {

    this.httpKlijent.post<NovaRegistracijaVM>(MojConfig.adresa_servera+"/Korisnik/Snimi",this.novaRegistracija).subscribe(
      (x:any)=>{this.router.navigateByUrl("/login");porukaSuccess("Uspješno ste se registrovali!")}
    )
  }

  BtnNovaRegistracija()
  {
    this.novaRegistracija={
      id: 0,
      ime: "",
      prezime: "",
      email: "",
      telefon: "",
      password: "",
      datumRodjenja: new Date(),
      dzematId: 1,
      korisnickoIme:""
    }
  }

  getDzemati() : void {
    this.httpKlijent.get(MojConfig.adresa_servera+"/Dzemat/GetAll").subscribe(x=>{this.dzematPodaci=x});
  }
}

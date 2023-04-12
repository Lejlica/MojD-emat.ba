import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {KorisnickiNalog} from "../_helpers/login-informacije";
declare function porukaSuccess(a: string):any;
@Component({
  selector: 'app-izmjena-lozinke',
  templateUrl: './izmjena-lozinke.component.html',
  styleUrls: ['./izmjena-lozinke.component.css']
})
export class IzmjenaLozinkeComponent implements OnInit {

  dzemati: any;
  korisnik: any;

  korisnNalog:KorisnickiNalog;
  korisnikInfo: any;
  provjeri_lozinku: any;
  alertd: boolean;
  prolaz:boolean;
  alertWarning:boolean;
  alertPostojeceKorisIme:boolean;

  constructor(private httpKlijent: HttpClient) { }

  ngOnInit(): void {
    this.alertd = false;
    this.getDzemati();
    this.getKorisnikInfo();
  }

  getDzemati()
  {
    this.httpKlijent.get(MojConfig.adresa_servera+"/Dzemat/GetAll").subscribe(x=>{this.dzemati=x});
  }

  getKorisnikInfo()
  {
    this.httpKlijent.get(MojConfig.adresa_servera+"/Autentifikacija/Get",MojConfig.http_opcije()).subscribe((x:any)=>{this.korisnik=x});
  }

  snimi() {

    this.httpKlijent.post(MojConfig.adresa_servera + "/KorisnickiNalog/Snimi?id=" + this.korisnik.korisnickiNalogId, this.korisnik, MojConfig.http_opcije()).subscribe(x=>
    {
      porukaSuccess("Uspješno spašene promjene!");
    });

  }


  odbaci() {
    this.getKorisnikInfo();
  }

}

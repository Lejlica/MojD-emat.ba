import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {KorisnickiNalog} from "../_helpers/login-informacije";
declare function porukaSuccess(a: string):any;
@Component({
  selector: 'app-postavke-profila',
  templateUrl: './postavke-profila.component.html',
  styleUrls: ['./postavke-profila.component.css']
})
export class PostavkeProfilaComponent implements OnInit {

  dzemati: any;
  korisnikj: any;

  korisnNalog:KorisnickiNalog;
  korisnikInfo: any;
  provjeri_lozinku: any;
  moderatorInfo: any;

  constructor(private httpKlijent: HttpClient) { }

  ngOnInit(): void {
    this.getLogiraniKorisnikInfo();
    //this.getKorisnikInfo();


  }

  getDzemati()
  {
    this.httpKlijent.get(MojConfig.adresa_servera+"/Dzemat/GetAll").subscribe(x=>{this.dzemati=x});
  }

  getLogiraniKorisnikInfo()
  {
    this.httpKlijent.get(MojConfig.adresa_servera+"/Autentifikacija/Get",MojConfig.http_opcije()).subscribe((x:any)=>{this.korisnikj=x; this.getKorisnikInfo()});
  }

  getKorisnikInfo()
  {
    if(this.korisnikj.korisnickiNalog.isModerator==true) {
      this.httpKlijent.get(MojConfig.adresa_servera + "/Moderator/GetById?id=" + this.korisnikj.korisnickiNalogId, MojConfig.http_opcije()).subscribe((x: any) => {
        this.korisnikInfo = x
      });

    }
    if(this.korisnikj.korisnickiNalog.isKorisnik==true) {
      this.httpKlijent.get(MojConfig.adresa_servera + "/Korisnik/GetAll?id=" + this.korisnikj.korisnickiNalogId, MojConfig.http_opcije()).subscribe((x: any) => {
        this.korisnikInfo = x
      });
    }
    if(this.korisnikj.korisnickiNalog.isImam==true) {
      this.httpKlijent.get(MojConfig.adresa_servera + "/Imam/GetById?id=" + this.korisnikj.korisnickiNalogId, MojConfig.http_opcije()).subscribe((x: any) => {
        this.korisnikInfo = x
      });
    }

  }


  snimi() {
    if(this.korisnikj.korisnickiNalog.isModerator==true) {
      this.httpKlijent.post(MojConfig.adresa_servera + "/Moderator/SnimiProfPostav?id="+this.korisnikj.korisnickiNalogId, this.korisnikInfo, MojConfig.http_opcije()).subscribe((x:any)=>{porukaSuccess("Uspješno spašene izmjene!")});
    }
    if(this.korisnikj.korisnickiNalog.isKorisnik==true) {
      this.httpKlijent.post(MojConfig.adresa_servera + "/Korisnik/SnimiProfPostav?id=" + this.korisnikj.korisnickiNalogId, this.korisnikInfo, MojConfig.http_opcije()).subscribe((x:any)=>{porukaSuccess("Uspješno spašene izmjene!")});
    }
    if(this.korisnikj.korisnickiNalog.isImam==true) {
      this.httpKlijent.post(MojConfig.adresa_servera + "/Imam/SnimiProfPostav?id=" + this.korisnikj.korisnickiNalogId, this.korisnikInfo, MojConfig.http_opcije()).subscribe((x:any)=>{porukaSuccess("Uspješno spašene izmjene!")});
    }
  }


  odbaci() {
    this.getKorisnikInfo();
  }
}

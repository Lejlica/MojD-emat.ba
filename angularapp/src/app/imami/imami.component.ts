import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-config";
declare function porukaSuccess(a: string):any;
@Component({
  selector: 'app-imami',
  templateUrl: './imami.component.html',
  styleUrls: ['./imami.component.css']
})
export class ImamiComponent implements OnInit {

  dzematPodaci: any;
  imam: any;
  imami: any;
  imeImama: any;

  constructor(private httpKlijent: HttpClient, private router: Router) {
  }

  ngOnInit(): void {
    this.getDzemati();
    this.getImami();
  }
  getDzemati() : void {
    this.httpKlijent.get(MojConfig.adresa_servera+"/Dzemat/GetAll").subscribe(x=>{this.dzematPodaci=x});
  }

  getImami() : void {
    this.httpKlijent.get(MojConfig.adresa_servera+"/Imam/GetAll").subscribe(x=>{this.imami =x});
  }
  getImamiPod()
  {
    if(this.imami==null)
      return [];
    if(this.imeImama!=null)
      return this.imami.filter((x:any)=>x.ime.toLowerCase().startsWith(this.imeImama.toLowerCase()));
    else return this.imami;
  }
  snimi()
  {
    this.httpKlijent.post(MojConfig.adresa_servera+"/Imam/Snimi",this.imam,MojConfig.http_opcije()).subscribe((x:any)=>{this.getImami();this.imam=null; porukaSuccess("Uspješno dodan imam!")});
  }

  obrisi(s:any)
  {
    this.httpKlijent.post(MojConfig.adresa_servera+"/Imam/Delete/"+s.id,null,MojConfig.http_opcije()).subscribe((x:any)=>{this.getImami();porukaSuccess("Uspješno obrisan imam!")});
  }

  dodajImama()
  {
    this.imam={
      id: 0,
      ime: "",
      prezime: "",
      email: "",
      telefon: "",
      lozinka: "",
      datumRodjenja: new Date(),
      dzematId: 1,
      korisnickoIme: "",
      salt: "string",
      fakultet: true,

      biografija:""
    }
  }

}

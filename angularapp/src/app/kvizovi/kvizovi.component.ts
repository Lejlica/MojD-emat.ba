import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-config";
declare function porukaSuccess(a: string):any;
@Component({
  selector: 'app-kvizovi',
  templateUrl: './kvizovi.component.html',
  styleUrls: ['./kvizovi.component.css']
})
export class KvizoviComponent implements OnInit {

  kvizovi: any;
  kvizId:number;
  pitanja: any;
  odabraniKviz: any;
  novaAktivacija: any;
  novoPokretanje: any;
   odabraniKvizUredi: any;
   moderatori: any;
  constructor(private httpKlijent: HttpClient, private router: Router) { }

  ngOnInit(): void {

    this.getKvizovi();
    this.getModeratori();
  }
  getKvizovi()
  {
    this.httpKlijent.get(MojConfig.adresa_servera+"/Kviz/GetAll",MojConfig.http_opcije()).subscribe((x:any)=>{this.kvizovi=x});
  }
  getKv()
  {
    if(this.kvizovi==null)
      return [];
    return this.kvizovi;
  }

  DodajPitanje(s:any) {
    this.router.navigate(["/dodaj-pitanje",s.id]);
  }

  GetPitanja(s:any) {
    this.httpKlijent.get(MojConfig.adresa_servera+"/KvizPitanje/GetAll?kvizId="+s.id).subscribe((x:any)=>{
      this.pitanja=x;
    });
  }
  GetPit()
  {
    if(this.pitanja==null)
      return [];
    return this.pitanja;
  }
  OdabraniKviz(s: any) {
    this.odabraniKviz=s;
    //this.GetPitanja(s);
    this.router.navigate(["/pregledaj-pitanja-za-kviz",s.id]);
  }

  //PokreniKviz(s: any) {
  //  this.router.navigate(["/kviz",s.id]);
  //}

  AktivirajKviz(s: any) {
    this.novaAktivacija=
      {
        id: 0,
        naziv: "",
        trajanjeMinute: 300,
        pocetak: new Date(),
        kraj: new Date(),
        kvizId: s.id
      }

    this.httpKlijent.post(MojConfig.adresa_servera+"/AktivacijaKviza/Add",this.novaAktivacija,MojConfig.http_opcije()).subscribe((x:any)=>{porukaSuccess("Uspješno aktiviran kviz!")});
  }


  PokreniKviz(s:any)
  {
    this.novoPokretanje={
      id: 0,
      vrijemePokretanja: new Date(),
      vrijemeZavrsetka:  new Date(),
      uspjeh: 0,

      aktivacijaKvizaId: 1
    }
    this.httpKlijent.post(MojConfig.adresa_servera+"/KorisnikKviz/Snimi",this.novoPokretanje).subscribe();
  }
  BtnUredi(s: any) {
    //this.odabraniKvizUredi=s;
    this.odabraniKvizUredi={
      id:s.id,
      naziv: s.naziv,
      vrstaKviza: s.vrstaKviza,
      datumKviza: s.datumKviza,
      brojPitanja: s.brojPitanja,
      moderatorId: 5,
      opis:s.opis
    }
  }
  BtnObrisi(s:any) {
    this.httpKlijent.post(MojConfig.adresa_servera+"/Kviz/Delete/"+s.id,null,MojConfig.http_opcije()).subscribe((x:any)=>{this.getKvizovi();porukaSuccess("Uspješno obrisan kviz!");});
  }

  odustani() {

  }

  snimi()
  {

    this.httpKlijent.post(MojConfig.adresa_servera+"/Kviz/Snimi",this.odabraniKvizUredi,MojConfig.http_opcije()).subscribe((x:any)=>{this.getKvizovi(); this.odabraniKvizUredi=null;porukaSuccess("Uspješno sačuvane promjene!")});

  }
  getModeratori() : void {
    this.httpKlijent.get(MojConfig.adresa_servera+"/Moderator/GetAll",MojConfig.http_opcije()).subscribe(x=>{this.moderatori=x});
  }

  dodajKviz() {
    this.router.navigateByUrl("add-kviz");
  }
}

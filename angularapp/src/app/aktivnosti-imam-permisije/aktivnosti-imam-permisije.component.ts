import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-config";
declare function porukaSuccess(a: string):any;
@Component({
  selector: 'app-aktivnosti-imam-permisije',
  templateUrl: './aktivnosti-imam-permisije.component.html',
  styleUrls: ['./aktivnosti-imam-permisije.component.css']
})
export class AktivnostiImamPermisijeComponent implements OnInit {
  aktivnosti_aktivne:any;
  aktivnosti_neaktivne:any;
  aktivnosti_zavrsene: any;
  novaPrijava: any;
  brojPrijava: any;
  odabranaAkt: any;
  novaAktivnost: any;
  aktivnostNaslov: any;

  constructor(private httpKlijent: HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.fetchAktivne();
    this.fetchZavrsene();
  }
  private fetchAktivne(){
    this.httpKlijent.get(MojConfig.adresa_servera+"/Aktivnost/GetAktivne",MojConfig.http_opcije()).subscribe((x:any)=>{this.aktivnosti_aktivne=x});

  }
  getAktivne()
  {
    if(this.aktivnosti_aktivne==null)
      return [];
    if(this.aktivnostNaslov!=null)
      return this.aktivnosti_aktivne.filter((x:any)=>x.naziv.toLowerCase().startsWith(this.aktivnostNaslov.toLowerCase()));
    else return this.aktivnosti_aktivne;
  }
  private fetchZavrsene(){
    this.httpKlijent.get(MojConfig.adresa_servera+"/Aktivnost/GetZavrsene",MojConfig.http_opcije()).subscribe((x:any)=>{this.aktivnosti_zavrsene=x});

  }
  getZavrsene()
  {
    if(this.aktivnosti_zavrsene==null)
      return [];
    return this.aktivnosti_zavrsene;
  }

  actionMethod(event: any) {
    event.target.disabled = true;
  }


  prijaviSeNaAktivnost(s:any) {

    this.novaPrijava={
      id: 0,
      vrijemePrijave: new Date(),
      aktivnost_id:s.id
    }
    this.httpKlijent.post(MojConfig.adresa_servera+"/PrijavaAktivnosti/Snimi?aktivnost_id="+s.id,this.novaPrijava,MojConfig.http_opcije()).subscribe((x:any)=>{ });

  }


  GetBrojPrijava(s: any) {
    this.httpKlijent.get(MojConfig.adresa_servera+"/Aktivnost/GetBrojPrijavaNaAktivnost?aktivnost_id="+s.id,MojConfig.http_opcije()).subscribe((x:any)=>{ this.brojPrijava=x});
  }

  OdabrnaAktivnost(s: any) {
    this.odabranaAkt=s;
    this.GetBrojPrijava(s);
  }

  BtnSnimi() {
    this.httpKlijent.post(MojConfig.adresa_servera+"/Aktivnost/Snimi",this.novaAktivnost,MojConfig.http_opcije()).subscribe((x:any)=>{ this.fetchAktivne();this.novaAktivnost=null;
    porukaSuccess("Uspješno dodana aktivnost!")});
  }

  BtnObrisi(s:any) {
    this.httpKlijent.post(MojConfig.adresa_servera+"/PrijavaAktivnosti/Delete/"+s.id,null,MojConfig.http_opcije()).subscribe((x:any)=>{ this.fetchAktivne();porukaSuccess("Uspješno obrisana aktivnost!")});
  }
  DodajAktivnost() {
    this.novaAktivnost={
      id:0,
      naziv:"",
      opis:"",
      datum:new Date(),
      lokacija:""
    }
  }

  BtnUredi(s: any) {
    this.novaAktivnost=s;
  }
}

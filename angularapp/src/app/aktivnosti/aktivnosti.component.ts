import { Component, OnInit } from '@angular/core';
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";

@Component({
  selector: 'app-aktivnosti',
  templateUrl: './aktivnosti.component.html',
  styleUrls: ['./aktivnosti.component.css']
})
export class AktivnostiComponent implements OnInit {

  aktivnosti_aktivne:any;
  aktivnosti_neaktivne:any;
  aktivnosti_zavrsene: any;
  novaPrijava: any;
  brojPrijava: any;


  constructor(private httpKlijent: HttpClient, private router: Router) {
  }

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
    return this.aktivnosti_aktivne;
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

  otkaziPrijavu(s:any) {
    this.httpKlijent.post(MojConfig.adresa_servera+"/PrijavaAktivnosti/Delete/"+s.id,this.novaPrijava,MojConfig.http_opcije()).subscribe((x:any)=>{ });
  }


}

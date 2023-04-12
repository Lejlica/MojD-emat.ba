import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-config";

@Component({
  selector: 'app-kvizovi-korisnik',
  templateUrl: './kvizovi-korisnik.component.html',
  styleUrls: ['./kvizovi-korisnik.component.css']
})
export class KvizoviKorisnikComponent implements OnInit {

  aktivacije: any;
  novoPokretanje: any;
  brojPitanja: any;

  constructor(private httpKlijent: HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.getAktivacije();
  }

  getAktivacije()
  {
    this.httpKlijent.get(MojConfig.adresa_servera+"/AktivacijaKviza/GetAll",MojConfig.http_opcije()).subscribe((x:any)=>{this.aktivacije=x});
  }
  getAktiv()
  {
    if(this.aktivacije==null)
      return [];
    return this.aktivacije;
  }

  KorisnikKviz(s: any) {
    this.novoPokretanje={
      id: 0,
      vrijemePokretanja: new Date(),
      vrijemeZavrsetka: new Date(),
      uspjeh: 0,
      aktivacijaKvizaId: s.id
    }
    this.httpKlijent.post(MojConfig.adresa_servera+"/KorisnikKviz/Snimi",this.novoPokretanje,MojConfig.http_opcije()).subscribe((x:any)=>{
      //this.router.navigate(["/pokreni-kviz-korisnik",s.kvizId]);
      this.router.navigate(["/get-pitanja-korisnik",s.kvizId]);
    });
  }



}

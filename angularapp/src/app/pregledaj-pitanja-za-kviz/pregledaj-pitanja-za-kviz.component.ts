import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute} from "@angular/router";
import {MojConfig} from "../moj-config";

@Component({
  selector: 'app-pregledaj-pitanja-za-kviz',
  templateUrl: './pregledaj-pitanja-za-kviz.component.html',
  styleUrls: ['./pregledaj-pitanja-za-kviz.component.css']
})
export class PregledajPitanjaZaKvizComponent implements OnInit {

  ponudjeniOdgovori: any;
  statusPitanja: any;
  brojPitanja: any;

  constructor(private httpKlijent: HttpClient, private route: ActivatedRoute) { }
  pitanja: any;
  kvizId:any;
  brojac:number=0;
  ngOnInit(): void {
    this.route.params.subscribe(x=>this.kvizId=+x["id"]);
    this.GetPitanja();
    this.GetBrojPitanja();
  }

  GetPitanja() {
    this.httpKlijent.get(MojConfig.adresa_servera+"/KvizPitanje/GetAll?kvizId="+this.kvizId).subscribe((x:any)=>{
      this.pitanja=x;
    });
  }
  GetPit()
  {
    if(this.pitanja==null)
      return [];
    return this.pitanja;
  }

  GetPonOdg(s:any)
  {
    this.httpKlijent.get(MojConfig.adresa_servera+"/PonudjeniOdgovor/GetPonOdgById?pitanjeId="+s.id).subscribe((x:any)=>{
      this.ponudjeniOdgovori=x;
    });
  }

  GetPO()
  {
    if(this.ponudjeniOdgovori==null)
      return [];
    return this.ponudjeniOdgovori;
  }

  SnimiIsActivePitanje(s:any)
  {
    this.statusPitanja={
      isActive:s.isActive
    }
    this.httpKlijent.post(MojConfig.adresa_servera+"/Pitanje/SnimiIsActivePitanje?pitanjeId="+s.pitanjeId,this.statusPitanja).subscribe();
  }

  GetBrojPitanja() {
    this.httpKlijent.get(MojConfig.adresa_servera+"/KvizPitanje/GetBrojPitanja?kvizId="+this.kvizId,MojConfig.http_opcije()).subscribe((x:any)=>{this.brojPitanja=x});
  }

}

import { Component, OnInit } from '@angular/core';
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
@Component({
  selector: 'app-dzemat-info',
  templateUrl: './dzemat-info.component.html',
  styleUrls: ['./dzemat-info.component.css']
})

export class DzematInfoComponent implements OnInit {
  dzematPodaci: any;
  imamPodaci: any;

  constructor(private httpKlijent:HttpClient) { }

  ngOnInit(): void {
    this.getDzematPodaci();
    this.getImamPodaci();
  }

  getDzematPodaci():void{
    this.httpKlijent.get(MojConfig.adresa_servera + "/Dzemat/GetAll?dzematId=1").subscribe(x=>{this.dzematPodaci=x;})
  }
  getSlika(){
    return MojConfig.adresa_servera + "/Dzemat/GetSlikaKorisnika/1";
  }
  getImamPodaci():void{
    this.httpKlijent.get(MojConfig.adresa_servera + "/Imam/GetAll?dzematId=1").subscribe(x=>{this.imamPodaci=x;})
  }
  getSlikaImama(){
    return MojConfig.adresa_servera + "/Imam/GetSlikaImama/1";//iz imamPodaci cmeo uzeti imamId
  }

}

export class Korisnickinalog{
  static korisnikID: number = 2;
}

import { Component, OnInit } from '@angular/core';
import {MojConfig} from "../moj-config";
import {ActivatedRoute} from "@angular/router";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-clanovi',
  templateUrl: './clanovi.component.html',
  styleUrls: ['./clanovi.component.css']
})
export class ClanoviComponent implements OnInit {



  clanoviPodaci:any;
  odabraniClan:any;
  nosiocPodaci:any;
  porodicaid: number|undefined;
  porodicapodaci: any;


  constructor(private httpKlijent:HttpClient, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.porodicaid = +params['id']; // (+) converts string 'id' to a number
      this.getClanove();//ovo ide ispod ove gornje funkcije ili cak u nju
      this.getPorodica();
    });


  }

  getClanove() {
    this.httpKlijent.get(MojConfig.adresa_servera + "/Clan/GetAll?id=" + this.porodicaid).subscribe(x=>{
      this.clanoviPodaci=x;
    })
  }

  getPorodica(){
    this.httpKlijent.get(MojConfig.adresa_servera + "/Porodica/GetAll?id=" + this.porodicaid).subscribe(x=>{
      this.porodicapodaci=x;
    })
  }
  noviClan() {
    this.odabraniClan={
      id: 0,
      ime: "",
      odnosSaNosiocem: "",
      prezime: this.porodicapodaci[0].prezime,
      status: "",
      datumrodjenja: "",
      napomena: "-",
      porodicaId: this.porodicaid,
      mekteb:false
    }
  }

  snimiClan() {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Clan/Add", this.odabraniClan).subscribe(x=>{
      this.getClanove();
      this.odabraniClan=null;
    });
  }
  izbrisiClana(id?:any) {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Clan/Delete/" + id, this.odabraniClan).subscribe(x=>{
      this.getClanove();
      this.odabraniClan=null;
    });
  }
  izbrisiPorodicu(id?:any) {
    // @ts-ignore
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Porodica/Delete/" + this.porodicaid).subscribe(x=>{
      this.otvoriMaticnu();
    });
  }
  otvoriMaticnu() {
    //this.route.navigate(['/putanja-porodice']);
  }
}

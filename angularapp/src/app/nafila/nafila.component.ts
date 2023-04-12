import { Component, OnInit } from '@angular/core';
import {MojConfig} from "../moj-config";
import {ActivatedRoute} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import {Korisnickinalog} from "../dzemat-info/dzemat-info.component";
@Component({
  selector: 'app-nafila',
  templateUrl: './nafila.component.html',
  styleUrls: ['./nafila.component.css']
})
export class NafilaComponent implements OnInit {

  constructor(private httpKlient:HttpClient, private router: ActivatedRoute) { }

  vjezbaPodaci:any;
  nafilaid: number|undefined;
  novaMojaNafila:any;


  ngOnInit(): void {
    this.router.params.subscribe(params => {
      this.nafilaid = +params['id']; // (+) converts string 'id' to a number
    });
    this.getVjezba();
  }

  getVjezba():void{
    this.httpKlient.get(MojConfig.adresa_servera + "/DuhovnaVjezba/GetAll?vjezbaId=" + this.nafilaid, MojConfig.http_opcije()).subscribe(x=>
    {this.vjezbaPodaci=x;})
  }

  getSlika(){
    return MojConfig.adresa_servera + "/DuhovnaVjezba/GetSlikaKorisnika/"+ this.nafilaid;
  }


  snimiNovuMojuNafilu() {
    this.novaMojaNafila = {
      id:0,
      duhovnaVjezbaId:this.nafilaid,
      korisnikId:Korisnickinalog.korisnikID,
      isFinished:false,
    };
    this.prijavaNaVjezbu();
  }


  prijavaNaVjezbu() {
    this.httpKlient.post(MojConfig.adresa_servera+ "/MojeVjezbe/Snimi", this.novaMojaNafila, MojConfig.http_opcije()).subscribe(x=>{
      this.novaMojaNafila=null;
    });
  }

}

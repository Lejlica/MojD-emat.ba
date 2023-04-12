import { Component, OnInit } from '@angular/core';
import {MojConfig} from "../moj-config";
import {Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import {Korisnickinalog} from "../dzemat-info/dzemat-info.component";
@Component({
  selector: 'app-moje-nafile',
  templateUrl: './moje-nafile.component.html',
  styleUrls: ['./moje-nafile.component.css']
})
export class MojeNafileComponent implements OnInit {
  mojaVjezbaPodaci: any;

  constructor(private httpKlient:HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.getMojaVjezba();
  }

  getMojaVjezba():void{
    this.httpKlient.get(MojConfig.adresa_servera + "/MojeVjezbe/GetAll?korisnikId=" + Korisnickinalog.korisnikID, MojConfig.http_opcije()).subscribe(x=>{this.mojaVjezbaPodaci=x;})
  }

  getSlika(x:any){
    return MojConfig.adresa_servera + "/DuhovnaVjezba/GetSlikaKorisnika/" + x.duhovnaVjezbaId;
  }

  otvoriDnevneVjezbe(x: any) {
    this.router.navigate(['/putanja-dnevnavjezba', x.duhovnaVjezbaId]);
  }
}

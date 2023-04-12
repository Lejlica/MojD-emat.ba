import { Component, OnInit } from '@angular/core';
import {MojConfig} from "../moj-config";
import {Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";
@Component({
  selector: 'app-sve-nafile',
  templateUrl: './sve-nafile.component.html',
  styleUrls: ['./sve-nafile.component.css']
})
export class SveNafileComponent implements OnInit {
  nafilePodaci: any;

  constructor(private httpKlient:HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.getVjezba();
  }

  getVjezba():void{
    this.httpKlient.get(MojConfig.adresa_servera + "/DuhovnaVjezba/GetAll", MojConfig.http_opcije()).subscribe(x=>{this.nafilePodaci=x;})
  }

  getSlika(id:any) {
    return MojConfig.adresa_servera + "/DuhovnaVjezba/GetSlikaKorisnika/" + id;
  }


  getDetaljiNafile(x:any) {
    this.router.navigate(['/putanja-nafila', x.id]);
  }
}

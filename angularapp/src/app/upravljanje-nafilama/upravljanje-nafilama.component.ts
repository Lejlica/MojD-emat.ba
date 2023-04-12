import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-config";

@Component({
  selector: 'app-upravljanje-nafilama',
  templateUrl: './upravljanje-nafilama.component.html',
  styleUrls: ['./upravljanje-nafilama.component.css']
})
export class UpravljanjeNafilamaComponent implements OnInit {
  vjezbaPodaci: any;

  constructor(private httpKlient:HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.getVjezba();
  }

  novaNafila() {
    this.router.navigate(["putanja-novaNafila"]);
  }
  getVjezba():void{
    this.httpKlient.get(MojConfig.adresa_servera + "/DuhovnaVjezba/GetAll?vjezbaId=", MojConfig.http_opcije()).subscribe(x=>{
      this.vjezbaPodaci=x;
    })
  }
  editNafila(x:any) {
    this.router.navigate(["putanja-upravljanjeNafilom", x.id]);
  }
}


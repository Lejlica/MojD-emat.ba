import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-config";
declare function porukaSuccess(a: string):any;
@Component({
  selector: 'app-add-kviz',
  templateUrl: './add-kviz.component.html',
  styleUrls: ['./add-kviz.component.css']
})
export class AddKvizComponent implements OnInit {

  noviKviz: any;
  moderatori: any;

  constructor(private httpKlijent: HttpClient,private router: Router) { }

  ngOnInit(): void {
    this.getModeratori();
    this.dodajKviz();
  }

  getModeratori() : void {
    this.httpKlijent.get(MojConfig.adresa_servera+"/Moderator/GetAll",MojConfig.http_opcije()).subscribe(x=>{this.moderatori=x});
  }
  snimi()
  {
    this.httpKlijent.post(MojConfig.adresa_servera+"/Kviz/Snimi",this.noviKviz,MojConfig.http_opcije()).subscribe((x:any)=>{porukaSuccess("Uspješno dodan kviz!")});
  }
  dodajKviz()
  {
    this.noviKviz={
      id:0,
      naziv: "",
      vrstaKviza: "",
      datumKviza: new Date(),
      brojPitanja: 20,
      moderatorId: 5,
      opis:""
    }
  }

  odustani() {
    this.router.navigate(["/kvizovi"]);
  }

}

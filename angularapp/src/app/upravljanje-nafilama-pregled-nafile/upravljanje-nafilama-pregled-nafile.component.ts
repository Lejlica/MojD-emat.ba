import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute, Router} from "@angular/router";
import {MojConfig} from "../moj-config";

@Component({
  selector: 'app-upravljanje-nafilama-pregled-nafile',
  templateUrl: './upravljanje-nafilama-pregled-nafile.component.html',
  styleUrls: ['./upravljanje-nafilama-pregled-nafile.component.css']
})
export class UpravljanjeNafilamaPregledNafileComponent implements OnInit {


  constructor(private httpKlient:HttpClient, private router: Router, private route: ActivatedRoute) { }

  nafilaId: number| undefined;
  vjezbaPodaci: any;
  dnevneVjezbePodaci: any;

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.nafilaId = +params['Id']; // (+) converts string 'id' to a number
      //ovo ide ispod ove gornje funkcije ili cak u nju
      this.getDnevneVjezbe();
      this.getVjezba();
    });
  }

  citajVjezbu(x: any) {

  }

  getDnevneVjezbe():void{
    this.httpKlient.get(MojConfig.adresa_servera + "/DnevnaVjezba/GetByVjezbaId/" + this.nafilaId).subscribe(x=>{this.dnevneVjezbePodaci=x;})
  }
  getVjezba():void{
    this.httpKlient.get(MojConfig.adresa_servera + "/DuhovnaVjezba/GetAll?vjezbaId=" + this.nafilaId).subscribe(x=>
    {this.vjezbaPodaci=x;})
  }

  novaDnevna() {
    this.router.navigate(["putanja-novaDnevna", this.nafilaId]);
  }
}

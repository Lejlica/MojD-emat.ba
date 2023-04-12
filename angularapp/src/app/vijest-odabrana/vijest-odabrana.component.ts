import { Component, OnInit } from '@angular/core';
import {VijestiVM} from "../vijesti/VijestiVM";
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute} from "@angular/router";
import {MojConfig} from "../moj-config";

@Component({
  selector: 'app-vijest-odabrana',
  templateUrl: './vijest-odabrana.component.html',
  styleUrls: ['./vijest-odabrana.component.css']
})
export class VijestOdabranaComponent implements OnInit {

  vijestId:number;
  vijestOdabranaPodaci:VijestiVM[]=[];
  constructor(private httpKlijent: HttpClient, private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.route.params.subscribe(x=>this.vijestId=+x["id"]);
    this.fetchPodaci();
  }
  fetchPodaci()
  {
    this.httpKlijent.get<VijestiVM>(MojConfig.adresa_servera+"/Vijest/GetById?vijestId="+this.vijestId).subscribe(
      (x:any)=>{this.vijestOdabranaPodaci=x});
  }

  getSlika(s: VijestiVM) {
    return `${MojConfig.adresa_servera}/Vijest/GetSlika/${s.id}`;
  }

}

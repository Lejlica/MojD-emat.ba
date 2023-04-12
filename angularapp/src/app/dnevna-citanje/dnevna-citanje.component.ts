import { Component, OnInit } from '@angular/core';
import {MojConfig} from "../moj-config";
import {ActivatedRoute, Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import { Location } from '@angular/common';
@Component({
  selector: 'app-dnevna-citanje',
  templateUrl: './dnevna-citanje.component.html',
  styleUrls: ['./dnevna-citanje.component.css']
})
export class DnevnaCitanjeComponent implements OnInit {
  dnevnaid: number | undefined;
  dnevnaPodaci: any;

  constructor(private httpKlijent:HttpClient, private route: ActivatedRoute,  private router: Router, private location:Location) { }


  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.dnevnaid = +params['id']; // (+) converts string 'id' to a number
      this.getDnevna();//ovo ide ispod ove gornje funkcije ili cak u nju

    });
  }


  getDnevna() {
    this.httpKlijent.get(MojConfig.adresa_servera + "/DnevnaVjezba/GetById?id=" + this.dnevnaid).subscribe(x=>{
      this.dnevnaPodaci=x;
    })
  }

  rutiaj() {
    this.location.back();
  }
}


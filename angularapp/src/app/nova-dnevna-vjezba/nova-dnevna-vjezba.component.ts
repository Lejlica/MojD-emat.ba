import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-nova-dnevna-vjezba',
  templateUrl: './nova-dnevna-vjezba.component.html',
  styleUrls: ['./nova-dnevna-vjezba.component.css']
})
export class NovaDnevnaVjezbaComponent implements OnInit {
  dnevnaDetalji: any;
  nafilaId: number|undefined;

  constructor(private httpKlient:HttpClient, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.nafilaId = +params['Id'];})

    this.dnevnaDetalji={
      id: 0,
      naslov: "",
      uvod: "",
      tekst: "",
      duhovnaVjezbaId: this.nafilaId
    }
  }

  spasiNovuDnevnuVjezbu() {
    this.httpKlient.post(MojConfig.adresa_servera+ "/DnevnaVjezba/Snimi", this.dnevnaDetalji).subscribe();
  }
}

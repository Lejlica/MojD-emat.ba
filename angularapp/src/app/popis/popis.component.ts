import { Component, OnInit } from '@angular/core';
import {MojConfig} from "../moj-config";
import {ActivatedRoute, Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-popis',
  templateUrl: './popis.component.html',
  styleUrls: ['./popis.component.css']
})
export class PopisComponent implements OnInit {

  filterPrezime:any="";
  filterMekteb: boolean=false;
  ucenik:any="Učenik";
  zaposlen:any="Zaposlen";
  nezaposlen:any="Nezaposlen";
  penzioner:any="Penzioner";
  filterDrop:any;
  constructor(private httpKlijent:HttpClient, private route: ActivatedRoute) { }

  podaciClanovi: any;

  ngOnInit(): void {
    this.getClanove();
  }

  getClanove() {
    this.httpKlijent.get(MojConfig.adresa_servera + "/Clan/GetAll").subscribe(x=>{
      this.podaciClanovi=x;
    })
  }

  odaberiUcenik() {
    this.filterDrop=this.ucenik;
  }
  odaberiZaposlen() {
    this.filterDrop=this.zaposlen;
  }
  odaberiNezaposlen() {
    this.filterDrop=this.nezaposlen;
  }
  odaberiPenzioner() {
    this.filterDrop=this.penzioner;
  }
  odaberiSvi() {
    this.filterDrop="";
  }
  getpodaci() {
    return this.podaciClanovi.filter((x:any)=>
      (x.prezime.toLowerCase().startsWith(this.filterPrezime.toLowerCase())
        ||
        x.ime.toLowerCase().startsWith(this.filterPrezime.toLowerCase()))
      &&
      (!this.filterMekteb|| x.mekteb==this.filterMekteb)
      &&
      (!this.filterDrop || x.status==this.filterDrop)
    );
  }



}

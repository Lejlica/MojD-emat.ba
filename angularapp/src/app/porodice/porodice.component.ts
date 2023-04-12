import { Component, OnInit } from '@angular/core';
import {MojConfig} from "../moj-config";
import {Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-porodice',
  templateUrl: './porodice.component.html',
  styleUrls: ['./porodice.component.css']
})
export class PorodiceComponent implements OnInit {



  constructor(private httpKlient:HttpClient, private router: Router) { }

  clanoviPodaci:any=[];
  porodicePodaci:any=[];
  filterPrezime:any="";
  filterClanIZ:boolean=false;
  filterClanHarema:boolean=false;
  odabranaPorodica:any;

  ngOnInit(): void {
    this.getPorodice();
  }

  getPorodice():void{
    this.httpKlient.get(MojConfig.adresa_servera + "/Porodica/GetAll").subscribe(x=>{this.porodicePodaci=x;})
  }


  getpodaci() {
    // @ts-ignore
    document.getElementById('f1').checked? this.filterClanHarema=true : this.filterClanHarema=false;
    // @ts-ignore
    document.getElementById('f2').checked? this.filterClanIZ=true : this.filterClanIZ=false;
    return this.porodicePodaci.filter((x:any)=>
      (x.prezime.toLowerCase().startsWith(this.filterPrezime.toLowerCase())
         ||
        x.nosiocPorodice.toLowerCase().startsWith(this.filterPrezime.toLowerCase()))
         &&
      (!this.filterClanIZ || x.clanoviIZ==this.filterClanIZ)
         &&
      (!this.filterClanHarema || x.clanoviHarema==this.filterClanHarema)
    );
  }
  btnFilteri() {


  }


  novaPorodica() {
    this.odabranaPorodica = {
      id:0,
      prezime:"",
      nosiocPorodice: "",
      lokacija:"",
      brojTelefona:"",
      adresa:"",
      dzematId:"1",
      clanoviIZ:false,
      clanoviHarema:false
    };
  }

  snimiPorodicu() {
    this.httpKlient.post(MojConfig.adresa_servera+ "/Porodica/Add", this.odabranaPorodica).subscribe(x=>{
      this.getPorodice();
      this.odabranaPorodica=null;
    });
  }

  otvoriClanove(x:any) {
    this.router.navigate(['/putanja-clanovi', x.id]);
  }

  otvoriPopis() {
    this.router.navigate(['/putanja-popis']);
  }


}

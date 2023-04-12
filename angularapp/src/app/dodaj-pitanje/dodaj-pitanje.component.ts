import { Component, OnInit } from '@angular/core';
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute, Router} from "@angular/router";
declare function porukaSuccess(a: string):any;
@Component({
  selector: 'app-dodaj-pitanje',
  templateUrl: './dodaj-pitanje.component.html',
  styleUrls: ['./dodaj-pitanje.component.css']
})
export class DodajPitanjeComponent implements OnInit {


  kvizId:number;
  novoPitanje: any;
  noviPonudjeniOdg: any;
  noviPonudjeniOdg2: any;
  noviPonudjeniOdg3: any;
  noviPonudjeniOdg4: any;
  novoKvizPitanje: any;
  pitanje: any;
  ponOdgovori: any;
  kvizovi: any;
  div1: boolean=true;
  constructor(private httpKlijent: HttpClient, private route: ActivatedRoute,private router: Router) { }

  ngOnInit(): void {
    this.route.params.subscribe(x=>this.kvizId=+x["id"]);

    this.NovoPitanje();

    this.NoviOdg();
    this.NoviOdgovor2();
    this.NoviOdgovor3();
    this.NoviOdgovor4();


  }

  DodajPitanjeIPonudjeneOdg() {

    this.httpKlijent.post(MojConfig.adresa_servera + "/Pitanje/Snimi", this.novoPitanje, MojConfig.http_opcije()).subscribe((x: any) => {
      this.getPitanjeDesc();
      porukaSuccess("Uspješno dodano pitanje!");
    });


  }
  NoviOdg(){
    this.noviPonudjeniOdg={
      id: 0,
      tekst:"",
      isCorrect: false,
    }
  }
  snimiOdg()
  {
    this.httpKlijent.post(MojConfig.adresa_servera+"/PonudjeniOdgovor/Snimi?pitanjeId="+this.pitanje[0].id,this.noviPonudjeniOdg,MojConfig.http_opcije()).subscribe((x:any)=>{porukaSuccess("Uspješno dodani ponuđeni odgovori!");window.location.reload()});
    this.httpKlijent.post(MojConfig.adresa_servera+"/PonudjeniOdgovor/Snimi?pitanjeId="+this.pitanje[0].id,this.noviPonudjeniOdg2,MojConfig.http_opcije()).subscribe();
    this.httpKlijent.post(MojConfig.adresa_servera+"/PonudjeniOdgovor/Snimi?pitanjeId="+this.pitanje[0].id,this.noviPonudjeniOdg3,MojConfig.http_opcije()).subscribe();
    this.httpKlijent.post(MojConfig.adresa_servera+"/PonudjeniOdgovor/Snimi?pitanjeId="+this.pitanje[0].id,this.noviPonudjeniOdg4,MojConfig.http_opcije()).subscribe();
  }
  getPitanjeDesc()
  {
    this.httpKlijent.get(MojConfig.adresa_servera+"/Pitanje/GetById",MojConfig.http_opcije()).subscribe((x:any)=>{this.pitanje=x; this.snimiKvPit()});
  }

  snimiNovoKvPitanje()
  {
    this.novoKvizPitanje={
      id: 0,
      kvizId: this.kvizId,
      pitanjeId: this.pitanje[0].id
    }

    this.httpKlijent.post(MojConfig.adresa_servera+"/KvizPitanje/Snimi",this.novoKvizPitanje).subscribe();
  }
  NovoPitanje()
  {
    this.novoPitanje={
      id:0,
      bodovi:10,
      tekst:"",
      isActive:true,
    }

  }
  NoviOdgovor2()
  {
    this.noviPonudjeniOdg2={
      id:0,
      tekst:"",
      isCorrect: false,
    }
  }
  NoviOdgovor3()
  {
    this.noviPonudjeniOdg3={
      id:0,
      tekst:"",
      isCorrect: false,
    }
  }
  NoviOdgovor4()
  {
    this.noviPonudjeniOdg4={
      id:0,
      tekst:"",
      isCorrect: false,
    }
  }

  getPonOdg() {
    this.httpKlijent.get(MojConfig.adresa_servera+"/PonudjeniOdgovor/GetAll",MojConfig.http_opcije()).subscribe((x:any)=>{this.ponOdgovori=x});
  }
  getO()
  {
    if(this.ponOdgovori==null)
      return [];
    return this.ponOdgovori;
  }

  snimiKvPit() {
    this.novoKvizPitanje={
      id: 0,
      kvizId: this.kvizId,
      pitanjeId: this.pitanje[0].id
    }

    this.httpKlijent.post(MojConfig.adresa_servera+"/KvizPitanje/Snimi",this.novoKvizPitanje).subscribe();

  }


  getKvizovi()
  {
    this.httpKlijent.get(MojConfig.adresa_servera+"/Kviz/GetAll").subscribe((x:any)=>{this.kvizovi=x});
  }

  odustani() {
    this.router.navigateByUrl("/kvizovi");
  }

  div1Function() {
    this.div1=false;
  }

}

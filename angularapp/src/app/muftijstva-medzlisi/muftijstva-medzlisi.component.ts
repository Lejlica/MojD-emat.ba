import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-config";
declare function porukaSuccess(a: string):any;
@Component({
  selector: 'app-muftijstva-medzlisi',
  templateUrl: './muftijstva-medzlisi.component.html',
  styleUrls: ['./muftijstva-medzlisi.component.css']
})
export class MuftijstvaMedzlisiComponent implements OnInit {

  muftijstva: any;
  medzlisi: any;
  novo_muftijstvo: any;
  novi_medzlis: any;
  nazivMedzlisa: any;
  nazivMuftijstva: any;

  constructor(private httpKlijent: HttpClient) { }

  ngOnInit(): void {
    this.getMuftijstva();
    this.getMedzlisi();

  }

  getMuftijstva()
  {
    this.httpKlijent.get(MojConfig.adresa_servera+"/Muftijstvo/GetAll").subscribe(x=>{this.muftijstva=x});
  }

  getMuft()
  {
    if(this.muftijstva==null)
      return [];
    if(this.nazivMuftijstva!=null)
      return this.muftijstva.filter((x:any)=>x.naziv.toLowerCase().startsWith(this.nazivMuftijstva.toLowerCase()));
    else return this.muftijstva;
  }

  getMedzlisi()
  {
    this.httpKlijent.get(MojConfig.adresa_servera+"/Medzlis/GetAll").subscribe(x=>{this.medzlisi=x});
  }

  getMedz()
  {
    if(this.medzlisi==null)
      return [];
    if(this.nazivMedzlisa!=null)
      return this.medzlisi.filter((x:any)=>x.naziv.toLowerCase().startsWith(this.nazivMedzlisa.toLowerCase()));
    else return this.medzlisi;
  }

  snimi() {
    this.httpKlijent.post(MojConfig.adresa_servera+"/Muftijstvo/Snimi?muftijstvo_id="+this.novo_muftijstvo.id,this.novo_muftijstvo).subscribe(x=>
    {
      this.getMuftijstva();
      this.novo_muftijstvo=null;
      porukaSuccess("Uspješno obavljeno!");
    });
  }

  DodajMuftijstvo() {
    this.novo_muftijstvo={
      id:0,
      naziv:"",
      telefon: "",
      adresa: "",
      fax: "",
      informacije: "",
      kontaktOsoba: ""
    }
  }

  ObrisiMedzlis(s:any) {
    this.httpKlijent.post(MojConfig.adresa_servera+"/Medzlis/Delete?id="+s.id,this.novo_muftijstvo).subscribe(x=>{this.getMedzlisi();
      porukaSuccess("Uspješno obrisano medžlis!");});

  }

  UrediMedzlis(s:any) {
    this.novi_medzlis=s;

  }

  ObrisiMuftijstvo(s:any) {
    this.httpKlijent.post(MojConfig.adresa_servera+"/Muftijstvo/Delete?id="+s.id,null).subscribe(x=>
    {
      this.getMuftijstva();
      this.novo_muftijstvo=null;
      porukaSuccess("Uspješno obrisano muftijstvo!");
    });

  }

  UrediMuftijstvo(s:any) {
    this.novo_muftijstvo=s;
  }

  snimiMedzlis() {
    this.httpKlijent.post(MojConfig.adresa_servera+"/Medzlis/Snimi?medzlis_id="+this.novi_medzlis.id,this.novi_medzlis).subscribe(x=>{
      this.getMedzlisi();
      this.novi_medzlis=null;
      porukaSuccess("Uspješno obavljeno!");
    });
  }

  DodajMedzlis() {
    this.novi_medzlis={
      id:0,
      naziv:"",
      telefon: "",
      adresa: "",
      fax: "",
      informacije: "",
      muftijstvoId:2
    }
  }

}

import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-config";
import {VijestiVM, VijestiVMPagedList} from "../vijesti/VijestiVM";
import {AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";
declare function porukaSuccess(a: string):any;
@Component({
  selector: 'app-vijesti-imam-permisije',
  templateUrl: './vijesti-imam-permisije.component.html',
  styleUrls: ['./vijesti-imam-permisije.component.css']
})
export class VijestiImamPermisijeComponent implements OnInit {
  //vijestiPodaci?:VijestiVMPagedList | null;
  // vijestiPodaci:VijestiVM[];
  vijestiPodaci:any;
  //novaVijest?:VijestiVM|null;
  novaVijest:any;
  currentPage:number=1;
  pageSize:number=5;
  vijestNaslov: any;



  pageNumberChanged($event:any)
  {
    this.fetchVijesti();
  }

  // public pageNumbersArray():number[]{
  //   let result=[];
  //  for(let i=0;i<this.totalPages();i++)
  //     result.push(i+1);
  //   return result;

  // }

  //private totalPages(){
  // if(this.vijestiPodaci!=null)
  //   return this.vijestiPodaci!.totalPages;
  // return 1;
  //}

  constructor(private httpKlijent: HttpClient, private router: Router) {
  }

  ngOnInit(): void {
    this.fetchVijesti();
  }

  fetchVijesti(){
    this.httpKlijent.get(MojConfig.adresa_servera+"/Vijest/GetAll1", MojConfig.http_opcije()).subscribe((x:any)=>{this.vijestiPodaci=x});

  }
  getPodaci()
  {
    if(this.vijestiPodaci==null)
      return [];
    if(this.vijestNaslov!=null)
      return this.vijestiPodaci.filter((x:any)=>x.naslov.toLowerCase().startsWith(this.vijestNaslov.toLowerCase()));
    else return this.vijestiPodaci;


  }

  getSlika(s: any) {
    return `${MojConfig.adresa_servera}/Vijest/GetSlika/${s.id}`;
  }

  BtnProcitajViseOVijest(s:any) {
    this.router.navigate(["/vijest-vijestOdabrana",s.id]);
  }

  BtnDodajVijest() {
    this.novaVijest={
      id:0,
      naslov:"",
      tekst:"",
      datum:new Date(),
      autor:AutentifikacijaHelper.getLoginInfo().autentifikacijaToken?.korisnickiNalog?.korisnickoIme,
      ImamId:1,
      image_nova_base64:"",
      opis:""
    }
  }
  generisi_preview() {
    // @ts-ignore
    var file=document.getElementById("slika-input").files[0];
    if(file)
    {
      var reader=new FileReader();
      let this2=this;
      reader.onload=function ()
      {
        this2.novaVijest.image_nova_base64= reader.result.toString();
      }
      reader.readAsDataURL(file);
    }
  }

  BtnSnimi() :void{
    this.httpKlijent.post(MojConfig.adresa_servera+"/Vijest/Snimi?vijest_id="+this.novaVijest.id,this.novaVijest,MojConfig.http_opcije()).subscribe((x:any)=>
    {porukaSuccess("Uspješno obavljeno!");
      this.fetchVijesti();});
    this.novaVijest=null;
  }

  Obrisi(s: any) {
    this.httpKlijent.post(MojConfig.adresa_servera+"/Vijest/Delete/"+s.id,null,MojConfig.http_opcije()).subscribe(x=>{this.fetchVijesti(); porukaSuccess("Uspješno obrisana vijest!")})
  }

  BtnUredi(s: any) {
    this.novaVijest=s;
  }

  BtnDodajSliku(s: any) {

  }

  goToPage(p:number)
  {
    this.currentPage=p;
    this.fetchVijesti();
  }

  goToPrev() {
    this.currentPage--;
  }

  goToNext() {
    this.currentPage++;
  }
}

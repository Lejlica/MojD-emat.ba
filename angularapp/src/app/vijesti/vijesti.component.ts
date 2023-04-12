import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Router} from "@angular/router";
import {VijestiVM, VijestiVMPagedList} from "./VijestiVM";
declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-vijesti',
  templateUrl: './vijesti.component.html',
  styleUrls: ['./vijesti.component.css']
})
export class VijestiComponent implements OnInit {

  vijestiPodaci?:VijestiVMPagedList | null;

  currentPage:number=1;
  pageSize:number=5;

  pageNumberChanged($event:any)
  {
    this.fetchVijesti();
  }

  public pageNumbersArray():number[]{
    let result=[];
    for(let i=0;i<this.totalPages();i++)
      result.push(i+1);
    return result;

  }

  private totalPages(){
    if(this.vijestiPodaci!=null)
      return this.vijestiPodaci!.totalPages;
    return 1;
  }

  constructor(private httpKlijent: HttpClient, private router: Router) {
  }

  ngOnInit(): void {
    this.fetchVijesti();
  }

  fetchVijesti(){
    this.httpKlijent.get<VijestiVMPagedList>(MojConfig.adresa_servera+"/Vijest/GetAll?pageNumber="+this.currentPage, MojConfig.http_opcije()).subscribe((x:any)=>{this.vijestiPodaci=x});

  }
  getPodaci()
  {
    if(this.vijestiPodaci==null)
      return [];
    return this.vijestiPodaci.dataItems;
  }

  getSlika(s: any) {
    return `${MojConfig.adresa_servera}/Vijest/GetSlika/${s.id}`;
  }

  BtnProcitajViseOVijest(s:any) {
    this.router.navigate(["/vijest-vijestOdabrana",s.id]);
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

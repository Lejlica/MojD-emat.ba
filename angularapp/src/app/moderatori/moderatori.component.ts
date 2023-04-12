import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-config";
import {DownloadFileService} from "../download-file.service";
declare function porukaSuccess(a: string):any;
@Component({
  selector: 'app-moderatori',
  templateUrl: './moderatori.component.html',
  styleUrls: ['./moderatori.component.css']
})
export class ModeratoriComponent implements OnInit {
  moderator: any;
  moderatori: any;
   moderatorIme: any;

  constructor(private httpKlijent: HttpClient, private router: Router,private downloadFileService:DownloadFileService) {
  }

  ngOnInit(): void {
    this.getModeratori();

  }



  DodajModeratora() {
    this.moderator={
      id: 0,
      ime: "",
      telefon: "061 207 153",
      prezime: "",
      email: "lejlaamaricc@gmail.com",
      lozinka: "",
      korisnickoIme: ""
    }
  }

  BtnSnimi() {
    this.httpKlijent.post(MojConfig.adresa_servera+"/Moderator/Add",this.moderator,MojConfig.http_opcije()).subscribe((x:any)=>{
      this.moderatori=null;
      porukaSuccess("Uspješno dodan moderator!");
    });
  }

  getModeratori()
  {
    this.httpKlijent.get(MojConfig.adresa_servera+"/Moderator/GetAll",MojConfig.http_opcije()).subscribe((x:any)=>{
      this.moderatori =x;
    });
  }

  getMod()
  {
    if(this.moderatori==null)
      return [];
    if(this.moderatorIme!=null)
      return this.moderatori.filter((x:any)=>x.ime.toLowerCase().startsWith(this.moderatorIme.toLowerCase()));
    else return this.moderatori;
  }

  public downloadFile():void{
    this.downloadFileService.downloadFile().subscribe(
      response=>
      {
        let fileName=response.headers.get('content-disposition')
          ?.split(';')[1].split('=')[1];
        let blob:Blob=response.body as Blob;
        let a=document.createElement('a');
        a.download=fileName;
        a.href=window.URL.createObjectURL(blob);
        a.click();
      }
    )
  }
}

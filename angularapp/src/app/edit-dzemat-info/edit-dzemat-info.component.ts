import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-config";

@Component({
  selector: 'app-edit-dzemat-info',
  templateUrl: './edit-dzemat-info.component.html',
  styleUrls: ['./edit-dzemat-info.component.css']
})
export class EditDzematInfoComponent implements OnInit {

  dzematPodaci: any;
  dzematDetalji:any;

  constructor(private httpKlient:HttpClient, private router: Router) { }



  ngOnInit(): void {
    this.dzematDetalji={
      id: 0,
      naziv: "",
      lokacijaDzamije: "Opine bb",
      info: "",
      kratkiOpis: "",
      dzematskiOdbor: "",
      medzlisId: 1,
      slika_nova_base64: ""
    }
    this.getSlika();
    this.getDzematPodaci();
  }
  spasiInformacije() {
    this.httpKlient.post(MojConfig.adresa_servera+ "/Dzemat/Snimi", this.dzematDetalji).subscribe();
  }
  generisi_preview() {
    // @ts-ignore
    var file = document.getElementById("slika-input").files[0];
    if (file) {
      var reader = new FileReader();
      let this2=this;
      reader.onload = function () {
        let base64string = reader.result;
        this2.dzematDetalji.slika_nova_base64 = base64string?.toString();
      }
      reader.readAsDataURL(file);
    }
  }

  getDzematPodaci():void{
    this.httpKlient.get(MojConfig.adresa_servera + "/Dzemat/GetAll?dzematId=2").subscribe(x=>{this.dzematPodaci=x;})
  }
  getSlika(){
    return MojConfig.adresa_servera + "/Dzemat/GetSlikaKorisnika/2";
  }

}

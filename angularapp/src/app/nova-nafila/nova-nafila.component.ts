import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-config";

@Component({
  selector: 'app-nova-nafila',
  templateUrl: './nova-nafila.component.html',
  styleUrls: ['./nova-nafila.component.css']
})
export class NovaNafilaComponent implements OnInit {

  constructor(private httpKlient:HttpClient) { }

  nafilaDetalji:any;

  ngOnInit(): void {

    this.nafilaDetalji={
      id: 0,
      naslov: "",
      opis: "",
      tekst: "",
      datumPocetka: "",
      datumZavrsetka: "",
      isActive: true,
      slika_nova_base64: "",
      moderatorId: 1,
    }
  }

  generisi_preview() {
    // @ts-ignore
    var file = document.getElementById("slika-input").files[0];
    if (file) {
      var reader = new FileReader();
      let this2=this;
      reader.onload = function () {
        let base64string = reader.result;
        this2.nafilaDetalji.slika_nova_base64 = base64string?.toString();
      }
      reader.readAsDataURL(file);
    }
  }

  spasiNovuNafilu() {
    this.httpKlient.post(MojConfig.adresa_servera+ "/DuhovnaVjezba/Snimi", this.nafilaDetalji).subscribe();
  }
}

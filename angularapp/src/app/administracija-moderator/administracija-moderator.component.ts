import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";

@Component({
  selector: 'app-administracija-moderator',
  templateUrl: './administracija-moderator.component.html',
  styleUrls: ['./administracija-moderator.component.css']
})
export class AdministracijaModeratorComponent implements OnInit {

  constructor(private httpKlient:HttpClient, private router: Router) { }

  ngOnInit(): void {
  }
  otvoriNovaNafila() {

  }

  otvoriNafile() {
    this.router.navigate(["putanja-upravljanjeNafilama"]);
  }

  otvoriMuftijstva() {
    this.router.navigate(["muftijstva-medzlisi"]);
  }

  otvoriKviz() {

    this.router.navigate(["kvizovi"]);
  }

  otvoriImame() {
    this.router.navigate(["imami"]);
  }

  otvoriModeratore() {
    this.router.navigate(["moderatori"]);
  }
}

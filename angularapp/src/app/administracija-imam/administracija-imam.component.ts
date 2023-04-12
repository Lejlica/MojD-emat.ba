import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";

@Component({
  selector: 'app-administracija-imam',
  templateUrl: './administracija-imam.component.html',
  styleUrls: ['./administracija-imam.component.css']
})
export class AdministracijaImamComponent implements OnInit {

  constructor(private httpKlient:HttpClient, private router: Router) { }

  ngOnInit(): void {
  }

  otvoriDzematInfo() {
    this.router.navigate(["putanja-EditDzematInfo"]);
  }

  otvoriNovaAktivnost() {
    this.router.navigate(["putanja-upravljanjeAktivnostima"]);
  }

  navigirajVijesti() {
    this.router.navigate(["vijesti-imam-permisije"]);
  }
  navigirajAktivnosti() {
    this.router.navigate(["aktivnosti-imam-permisije"]);
  }

  navigirajKviz() {
    this.router.navigate(["kvizovi"]);
  }
}


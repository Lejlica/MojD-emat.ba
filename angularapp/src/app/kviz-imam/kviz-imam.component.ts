import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";

@Component({
  selector: 'app-kviz-imam',
  templateUrl: './kviz-imam.component.html',
  styleUrls: ['./kviz-imam.component.css']
})
export class KvizImamComponent implements OnInit {
  constructor(private httpKlijent: HttpClient, private router: Router) { }
  ngOnInit(): void {
  }

  navigiraj() {
    this.router.navigateByUrl("/add-kviz");
  }

  navigiraj2() {
    this.router.navigateByUrl("/kvizovi");
  }

  navigirajNaVijesti() {
    this.router.navigateByUrl("/vijesti-imam-permisije");
  }

  navigirajNaAktivnosti() {
    this.router.navigateByUrl("/aktivnosti-imam-permisije");
  }

}

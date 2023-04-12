import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";

@Component({
  selector: 'app-admin-profil',
  templateUrl: './admin-profil.component.html',
  styleUrls: ['./admin-profil.component.css']
})
export class AdminProfilComponent implements OnInit {

  constructor(private httpKlijent: HttpClient, private router: Router) { }

  ngOnInit(): void {
  }

  navigiraj() {
    this.router.navigateByUrl("/moderatori");
  }

  navigiraj2() {
    this.router.navigateByUrl("/imami");
  }

}

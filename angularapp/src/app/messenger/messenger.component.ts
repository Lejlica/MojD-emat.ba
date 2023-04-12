import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {Hub_servis} from "../_servisi/hub_servis";


@Component({
  selector: 'app-messenger',
  templateUrl: './messenger.component.html',
  styleUrls: ['./messenger.component.css']
})
export class MessengerComponent implements OnInit {

  constructor(private httpKlient:HttpClient, private router: Router, public servis:Hub_servis) {
    servis.otvoriKanal();
  }


  ngOnInit(): void {
    const myScrollableDiv = document.getElementById("myScrollableDiv") as HTMLElement;
    myScrollableDiv.scrollTop = myScrollableDiv.scrollHeight - myScrollableDiv.clientHeight;;
  }


}

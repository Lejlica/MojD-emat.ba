import { Component, OnInit } from '@angular/core';
import {MojConfig} from "../moj-config";
import {ActivatedRoute} from "@angular/router";
import {Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";
@Component({
  selector: 'app-dnevne-vjezbe',
  templateUrl: './dnevne-vjezbe.component.html',
  styleUrls: ['./dnevne-vjezbe.component.css']
})
export class DnevneVjezbeComponent implements OnInit {

  constructor(private httpKlijent:HttpClient, private route: ActivatedRoute,  private router: Router) { }

  dnevneVjezbePodaci: any;
  vjezbaId: number | undefined;

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.vjezbaId = +params['vjezbaId']; // (+) converts string 'id' to a number
      this.getDnevneVjezbe();
    });
  }

  getDnevneVjezbe():void{
    this.httpKlijent.get(MojConfig.adresa_servera + "/DnevnaVjezba/GetByVjezbaId/" + this.vjezbaId).subscribe(x=>{this.dnevneVjezbePodaci=x;})
  }


  citajVjezbu(x: any) {
    this.router.navigate(['/putanja-dnevnacitanje', x.id]);
  }
}

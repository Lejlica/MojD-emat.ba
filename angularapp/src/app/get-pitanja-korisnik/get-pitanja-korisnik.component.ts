import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute, Router} from "@angular/router";
import {MojConfig} from "../moj-config";

@Component({
  selector: 'app-get-pitanja-korisnik',
  templateUrl: './get-pitanja-korisnik.component.html',
  styleUrls: ['./get-pitanja-korisnik.component.css']
})
export class GetPitanjaKorisnikComponent implements OnInit {

  korisnik: any;
  brojac:number=1;
  pitanja: any;
  kvizId: number;
  brojPitanja: any;
  odgovori: any;
  brojac1:number=0;
  odabraniOdg: string;
  kkp: any;

  pitanjaa:any;
  constructor(private httpKlijent: HttpClient, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.route.params.subscribe(x=>this.kvizId=+x["id"]);
    this.GetKorisnik();
    this.GetBrojPitanja();

  }

  GetKorisnik()
  {
    this.httpKlijent.get(MojConfig.adresa_servera+"/KorisnikKviz/GetAll?kvizId="+this.kvizId,MojConfig.http_opcije()).subscribe((x:any)=>{
      this.korisnik=x;
      this.GenerisiPitanja();
    })
  }
//generisati pitanja i pozvati getkorinsikpitanja /KorisnikKvizPitanja/GenerisiPitanja?kvizId=5&korisnikKvizId=
  otvoriModal: any;
  div1:boolean=false;

  GenerisiPitanja()
  {
    this.httpKlijent.post(MojConfig.adresa_servera+"/KorisnikKvizPitanja/GenerisiPitanja?kvizId="+this.kvizId+"&korisnikKvizId="+this.korisnik[0].id,MojConfig.http_opcije()).subscribe((x:any)=>{
      this.GetKorisnikKvizPitanja();
    });
  }
  GetKorisnikKvizPitanja()
  {
    this.httpKlijent.get(MojConfig.adresa_servera+"/KorisnikKvizPitanja/GetAll?korisnikKvizId="+this.korisnik[0].id,MojConfig.http_opcije()).subscribe((x:any)=>{
      this.pitanja=x;
    })
  }

  GetKKPitanja()
  {
    if(this.pitanja==null)
      return [];
    return this.pitanja;
  }

  next() {
    if(this.brojac<this.brojPitanja)
      this.brojac++;

    //pozvati snimi oznaceni odgovor
  }

  back() {
    if(this.brojac>=1)
      this.brojac--;
  }

  GetBrojPitanja() {
    this.httpKlijent.get(MojConfig.adresa_servera+"/KvizPitanje/GetBrojPitanja?kvizId="+this.kvizId,MojConfig.http_opcije()).subscribe((x:any)=>{this.brojPitanja=x});
  }

  SnimiOdgovor(o:any)
  {
    this.odgovori={
      korisnikKvizId: this.korisnik[0].id,
      pitanjas: [
        {
          korisnikKvizPitanjaID: this.pitanja.pitanja[this.brojac-1].id,
          oznaceniOdgovoriIDs: [
            o.id
          ],
          pitanjeId: this.pitanja.pitanja[this.brojac-1].pitanje.id
        }
      ]

    }
    this.httpKlijent.post(MojConfig.adresa_servera+"/KorisnikKvizPitanja/Snimi",this.odgovori,MojConfig.http_opcije()).subscribe();
  }


  GetOdabraniOdgovori(s:any)
  {
    this.httpKlijent.get(MojConfig.adresa_servera+"/KorisnikKvizPitanja/OdabraniOdgovorGetById?kvizId="+this.kvizId+"&korisnikKvizPitanjaId="+s).subscribe((x:any)=>{this.odabraniOdg=x.oznaceniOdgTekst;

    });
  }
  GetOdg()
  {
    if(this.kkp==null)
      return [];
    return this.kkp;
  }
  dereferenciraj()
  {
    if(this.brojac1<this.brojPitanja)
      this.brojac1++;
    //for(let i=0;i<this.brojPitanja;i++)
    //{
    this.kkp=this.pitanja.pitanja[this.brojac1-1].id;
    this.GetOdabraniOdgovori(this.kkp);

    this.GetPitanja();

    //}

  }

  nazad()
  {
    if(this.brojac1>=1)
      this.brojac1--;
    //for(let i=0;i<this.brojPitanja;i++)
    //{
    this.kkp=this.pitanja.pitanja[this.brojac1-1].id;
    this.GetOdabraniOdgovori(this.kkp);

    this.GetPitanja();

    //}

  }

  GetPitanja() {
    this.httpKlijent.get(MojConfig.adresa_servera+"/KvizPitanje/GetAll?kvizId="+this.kvizId).subscribe((x:any)=>{
      this.pitanjaa=x;
    });
  }

  GetPit()
  {
    if(this.pitanja==null)
      return [];
    return this.pitanja;
  }


  div1Function() {
    this.div1=true;
  }

  odustani() {
    window.location.reload();
  }

}

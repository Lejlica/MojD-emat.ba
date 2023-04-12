import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule} from "@angular/forms"
import { AppComponent } from './app.component';
import { HttpClientModule} from "@angular/common/http";

import { RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegistracijaComponent } from './registracija/registracija.component';

import {AutorizacijaLoginProvjera} from "./_guards/autorizacija-login-provjera.service";
import { NotFoundComponent } from './not-found/not-found.component';

import {PorodiceComponent} from './porodice/porodice.component';

import {VijestiComponent} from "./vijesti/vijesti.component";
import { VijestOdabranaComponent } from './vijest-odabrana/vijest-odabrana.component';
import { VijestiImamPermisijeComponent } from './vijesti-imam-permisije/vijesti-imam-permisije.component';
import { AktivnostiComponent } from './aktivnosti/aktivnosti.component';
import { AktivnostiImamPermisijeComponent } from './aktivnosti-imam-permisije/aktivnosti-imam-permisije.component';
import { PostavkeProfilaComponent } from './postavke-profila/postavke-profila.component';
import { IzmjenaLozinkeComponent } from './izmjena-lozinke/izmjena-lozinke.component';
import { ModeratoriComponent } from './moderatori/moderatori.component';
import { AdminProfilComponent } from './admin-profil/admin-profil.component';
import { ImamiComponent } from './imami/imami.component';
import {DownloadFileService} from "./download-file.service";
import { TwoFOtkljucajComponent } from './two-f-otkljucaj/two-f-otkljucaj.component';
import { MuftijstvaMedzlisiComponent } from './muftijstva-medzlisi/muftijstva-medzlisi.component';
import { AddKvizComponent } from './add-kviz/add-kviz.component';
import { KvizoviComponent } from './kvizovi/kvizovi.component';
import { KvizImamComponent } from './kviz-imam/kviz-imam.component';
import { DodajPitanjeComponent } from './dodaj-pitanje/dodaj-pitanje.component';
import { PregledajPitanjaZaKvizComponent } from './pregledaj-pitanja-za-kviz/pregledaj-pitanja-za-kviz.component';
import { KvizoviKorisnikComponent } from './kvizovi-korisnik/kvizovi-korisnik.component';
import { GetPitanjaKorisnikComponent } from './get-pitanja-korisnik/get-pitanja-korisnik.component';
import { ClanoviComponent } from './clanovi/clanovi.component';
import { PopisComponent } from './popis/popis.component';
import { DzematInfoComponent } from './dzemat-info/dzemat-info.component';
import { EditDzematInfoComponent } from './edit-dzemat-info/edit-dzemat-info.component';
import { AdministracijaImamComponent } from './administracija-imam/administracija-imam.component';
import { AdministracijaModeratorComponent } from './administracija-moderator/administracija-moderator.component';
import { UpravljanjeNafilamaComponent } from './upravljanje-nafilama/upravljanje-nafilama.component';
import { UpravljanjeNafilamaPregledNafileComponent } from './upravljanje-nafilama-pregled-nafile/upravljanje-nafilama-pregled-nafile.component';
import { NovaNafilaComponent } from './nova-nafila/nova-nafila.component';
import { NovaDnevnaVjezbaComponent } from './nova-dnevna-vjezba/nova-dnevna-vjezba.component';
import { MessengerComponent } from './messenger/messenger.component';
import { SveNafileComponent } from './sve-nafile/sve-nafile.component';
import { NafilaComponent } from './nafila/nafila.component';
import { MojeNafileComponent } from './moje-nafile/moje-nafile.component';
import { DnevneVjezbeComponent } from './dnevne-vjezbe/dnevne-vjezbe.component';
import { DnevnaCitanjeComponent } from './dnevna-citanje/dnevna-citanje.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegistracijaComponent,
    NotFoundComponent,
    PorodiceComponent,
    VijestiComponent,
    VijestOdabranaComponent,
    VijestiImamPermisijeComponent,
    AktivnostiComponent,
    AktivnostiImamPermisijeComponent,
    PostavkeProfilaComponent,
    IzmjenaLozinkeComponent,
    ModeratoriComponent,
    AdminProfilComponent,
    ImamiComponent,
    TwoFOtkljucajComponent,
    MuftijstvaMedzlisiComponent,
    AddKvizComponent,
    KvizoviComponent,
    KvizImamComponent,
    DodajPitanjeComponent,
    PregledajPitanjaZaKvizComponent,
    KvizoviKorisnikComponent,
    GetPitanjaKorisnikComponent,
    ClanoviComponent,
    PopisComponent,
    DzematInfoComponent,
    EditDzematInfoComponent,
    AdministracijaImamComponent,
    AdministracijaModeratorComponent,
    UpravljanjeNafilamaComponent,
    UpravljanjeNafilamaPregledNafileComponent,
    NovaNafilaComponent,
    NovaDnevnaVjezbaComponent,
    MessengerComponent,
    SveNafileComponent,
    NafilaComponent,
    MojeNafileComponent,
    DnevneVjezbeComponent,
    DnevnaCitanjeComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot([

      {path: 'login', component: LoginComponent},
      {path: 'registracija', component: RegistracijaComponent},
      {path: 'vijesti', component: VijestiComponent, canActivate: [AutorizacijaLoginProvjera]},
      {path: 'imami', component: ImamiComponent, canActivate: [AutorizacijaLoginProvjera]},
      {path: 'add-kviz', component: AddKvizComponent, canActivate: [AutorizacijaLoginProvjera]},
      {path: 'kvizovi', component: KvizoviComponent, canActivate: [AutorizacijaLoginProvjera]},
      {path: 'dodaj-pitanje/:id', component: DodajPitanjeComponent, canActivate: [AutorizacijaLoginProvjera]},
      {path:'get-pitanja-korisnik/:id',component:GetPitanjaKorisnikComponent},
      {path:'kvizovi-korisnik',component:KvizoviKorisnikComponent},
      {path:'pregledaj-pitanja-za-kviz/:id',component:PregledajPitanjaZaKvizComponent},
      {path: 'kviz-imam', component: KvizImamComponent, canActivate: [AutorizacijaLoginProvjera]},
      {path: 'admin-profil', component: AdminProfilComponent, canActivate: [AutorizacijaLoginProvjera]},
      {path: 'two-f-otkljucaj', component: TwoFOtkljucajComponent, canActivate: [AutorizacijaLoginProvjera]},
      {path: 'muftijstva-medzlisi', component: MuftijstvaMedzlisiComponent, canActivate: [AutorizacijaLoginProvjera]},
      {path: 'vijesti-imam-permisije', component: VijestiImamPermisijeComponent, canActivate: [AutorizacijaLoginProvjera]},
      {path: 'vijest-vijestOdabrana/:id', component: VijestOdabranaComponent, canActivate: [AutorizacijaLoginProvjera]},
      {path: 'aktivnosti', component: AktivnostiComponent, canActivate: [AutorizacijaLoginProvjera]},
      {path: 'aktivnosti-imam-permisije', component: AktivnostiImamPermisijeComponent, canActivate: [AutorizacijaLoginProvjera]},
      {path: 'postavke-profila', component: PostavkeProfilaComponent, canActivate: [AutorizacijaLoginProvjera]},
      {path: 'izmjena-lozinke', component: IzmjenaLozinkeComponent, canActivate: [AutorizacijaLoginProvjera]},
      {path: 'moderatori', component: ModeratoriComponent, canActivate: [AutorizacijaLoginProvjera]},
      //{path: '**', component: NotFoundComponent, canActivate: [AutorizacijaLoginProvjera]},

      {path: 'putanja-porodice', component: PorodiceComponent, canActivate: [AutorizacijaLoginProvjera]},
      {path: 'putanja-clanovi/:id', component: ClanoviComponent, canActivate: [AutorizacijaLoginProvjera]},
      {path:'putanja-popis', component:PopisComponent, canActivate: [AutorizacijaLoginProvjera]},
      {path:'putanja-info', component:DzematInfoComponent, canActivate: [AutorizacijaLoginProvjera]},
      {path:'putanja-EditDzematInfo', component:EditDzematInfoComponent, canActivate: [AutorizacijaLoginProvjera]},
      {path:'putanja-administracijaImam', component:AdministracijaImamComponent, canActivate: [AutorizacijaLoginProvjera]},
      {path:'putanja-administracijaModerator', component:AdministracijaModeratorComponent, canActivate: [AutorizacijaLoginProvjera]},
      {path:'putanja-upravljanjeNafilama', component:UpravljanjeNafilamaComponent, canActivate: [AutorizacijaLoginProvjera]},
      {path:'putanja-upravljanjeNafilom/:Id', component:UpravljanjeNafilamaPregledNafileComponent, canActivate: [AutorizacijaLoginProvjera]},
      {path:'putanja-novaNafila', component:NovaNafilaComponent, canActivate: [AutorizacijaLoginProvjera]},
      {path:'putanja-novaDnevna/:Id', component:NovaDnevnaVjezbaComponent, canActivate: [AutorizacijaLoginProvjera]},
      {path:'putanja-messenger', component:MessengerComponent, canActivate: [AutorizacijaLoginProvjera]},
      {path:'putanja-svenafile', component:SveNafileComponent, canActivate: [AutorizacijaLoginProvjera]},
      {path:'putanja-nafila/:id', component:NafilaComponent, canActivate: [AutorizacijaLoginProvjera]},
      {path:'putanja-mojenafile', component:MojeNafileComponent, canActivate: [AutorizacijaLoginProvjera]},
      {path:'putanja-dnevnavjezba/:vjezbaId', component:DnevneVjezbeComponent, canActivate: [AutorizacijaLoginProvjera]},
      {path:'putanja-dnevnacitanje/:id', component:DnevnaCitanjeComponent, canActivate: [AutorizacijaLoginProvjera]},
    ]),
    FormsModule,
    HttpClientModule,
  ],
  providers: [
    AutorizacijaLoginProvjera,
    DownloadFileService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

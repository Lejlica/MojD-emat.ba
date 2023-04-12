import {Injectable} from "@angular/core";
import * as signalR from "@microsoft/signalr";
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
@Injectable({
  providedIn:"root"
  }

)


export class Hub_servis{

  public poruka:string="";
  public signaldata:any[]=[];
  connection?:signalR.HubConnection | null;

  otvoriKanal() {
    //this.connection = new signalR.HubConnectionBuilder()
    //  .withUrl(MojConfig.adresa_servera+'/hub-putanja')
    //  .build();

    this.connection = new signalR.HubConnectionBuilder()
      .configureLogging(signalR.LogLevel.Debug)
      .withUrl(MojConfig.adresa_servera+'/hub-putanja', {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
      })
      .build();

    this.connection.on('PosaljiPoruku', (p:string)=>{
      this.poruka = p;
      this.signaldata.push(this.poruka);
      this.poruka="";
    });

    this.connection.start().then(()=>{
        console.log("otvoren kanal WS");
      }
    );

  }

  posaljiImePrezime()
  {
    if (this.poruka!="")
    {
    this.connection?.invoke("ProslijediPoruku", this.poruka);
    this.signaldata.push(this.poruka);
    localStorage.setItem('data', JSON.stringify(this.poruka));
    this.poruka="";
    }
  }
}

// NovaPoruka() {
//   this.httpKlient.post(MojConfig.adresa_servera+ "/Hub/Add", this.Novaporuka).subscribe();
// }

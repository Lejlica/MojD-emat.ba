import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "./moj-config";

@Injectable({
  providedIn: 'root'
})
export class DownloadFileService {

  constructor(private httpKlijent: HttpClient) { }

  downloadFile()
  {
    return this.httpKlijent.get(MojConfig.adresa_servera+"/Report1/Index",
      {observe:'response', responseType:'blob'})
  }
}

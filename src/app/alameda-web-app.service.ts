import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AlamedaWebAppService {

  constructor(private http: HttpClient) { }

  returnData()
  {
    
    return this.http.get('https://localhost:7054/api/alameda_web_app_/Bleach', {responseType: 'text'});
  
  }

 
}

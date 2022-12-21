import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AlamedaWebAppService {

  constructor(private http: HttpClient) { }

  returnData()
  {
    //r
    return this.http.get('https://localhost:7054/api/alameda_web_app_/Bleach', {responseType: 'text'});
    /*
    GetUserName() {
      this.http.get(this.baseUrl + 'api/Common/GetUserName/' + this.StaffCode, {responseType: text'}).subscribe(result => {
        sessionStorage.setItem("UserName", result);
        alert(sessionStorage.getItem("UserName"));
      }, error => console.log(error));*/
    }
}

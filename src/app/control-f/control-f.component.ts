import { HttpHeaders } from '@angular/common/http';
import { Component, OnInit, Input, SimpleChanges } from '@angular/core';
import { AlamedaWebAppService } from '../alameda-web-app.service';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import { HttpParams } from '@angular/common/http';





@Component({
  selector: 'app-control-f',
  templateUrl: './control-f.component.html',
  styleUrls: ['./control-f.component.css']
})
export class ControlFComponent implements OnInit{

  //@Input() entered: any;

 

  entered:any;//aka search from home component input
  filter:string='';//the entered string in the control-f component input field
  result:any;//again this needs to be in the results page component. using this here for testing
  //returnedBleach:any;//from GetB() funcion in C#

  sendBackend = {//prob delete
    name: "Bleach String",
    filter: this.filter
  }





  constructor(private alamedaWebAppService : AlamedaWebAppService, private http: HttpClient){}

  ngOnInit(): void{
    this.entered = localStorage.getItem('search');

    this.alamedaWebAppService.returnData().subscribe(data => {this.result=data;});//this needs to be in the results page component

    
  }

  onSubmit()
  {/*
    this.http.post('https://localhost:7054/api/alameda_web_app_/UpdateBleach',{id: 0, name: this.filter}, 
    this.httpOptions).subscribe(x=> console.log(x));*/

    /*let bar: any = new Object();
  bar.foo = 'Hello World';
    */

    this.http.post<any>('https://localhost:7054/api/alameda_web_app_', {code: this.filter}).subscribe(
      x=> console.log(x));

  }

  ngOnchanges(changes: SimpleChanges)
  {
    console.log(changes);
  }

  



}

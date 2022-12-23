import { HttpHeaders } from '@angular/common/http';
import { Component, OnInit, Input, SimpleChanges } from '@angular/core';
import { AlamedaWebAppService } from '../alameda-web-app.service';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-results',
  templateUrl: './results.component.html',
  styleUrls: ['./results.component.css']
})
export class ResultsComponent {

  returnedBleach:any;
  returnedBleachArray: string[] = [];
  
  constructor(private http: HttpClient){}

  ngOnInit(): void{
    /*
    this.http.get('https://localhost:7054/api/alameda_web_app_/Bleach', 
    {responseType: 'text'}).subscribe(data => {this.returnedBleach=data;})//this is working
    */

    this.http.get<string[]>('https://localhost:7054/api/alameda_web_app_/Bleach').subscribe(data => {this.returnedBleachArray=data;})


    

    
  }
/*
  ngOnInit(): void{
    this.entered = localStorage.getItem('search');

    this.alamedaWebAppService.returnData().subscribe(data => {this.result=data;});//this needs to be in the results page component

    
  }*/

}
/*
this.http.get('https://localhost:7054/api/alameda_web_app_/BleachUpdated', 
{responseType: 'text'}).subscribe(data => {this.returnedBleach=data;})
*/
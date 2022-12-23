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

 

  homeString:any;//aka search from home component input
  pattern:string='';//the entered string in the control-f component input field
  result:any;//again this needs to be in the results page component. using this here for testing
  //returnedBleach:any;//from GetB() funcion in C#

  regexFlag:boolean=false;
  matchCaseFlag:boolean=false;
  wholeWordFlag:boolean=false;



  





  constructor(private alamedaWebAppService : AlamedaWebAppService, private http: HttpClient){}

  ngOnInit(): void{
    this.homeString = localStorage.getItem('search');

    //this.alamedaWebAppService.returnData().subscribe(data => {this.result=data;});//this needs to be in the results page component

    
  }

  onSubmit()
  {/*
    this.http.post('https://localhost:7054/api/alameda_web_app_/UpdateBleach',{id: 0, name: this.filter}, 
    this.httpOptions).subscribe(x=> console.log(x));*/

    /*let bar: any = new Object();
  bar.foo = 'Hello World';
    */
/*
  console.log(this.regexFlag);
  console.log(this.matchCaseFlag);
  console.log(this.wholeWordFlag);
*/
    this.http.post<any>('https://localhost:7054/api/alameda_web_app_', {pattern: this.pattern, homeString: this.homeString,
  regexFlag: this.regexFlag, matchCaseFlag: this.matchCaseFlag, wholeWordFlag: this.wholeWordFlag}).subscribe(
      x=> console.log(x));//need to also post the entry on home component. the coders eat cod shit
      //homeString was sending NULL becuase it was named stringToSend: this.homeString. YOU REALLY HAVE TO MATCH the .net
      //class variable name side

  }

  ngOnchanges(changes: SimpleChanges)
  {
    console.log(changes);
  }

  



}

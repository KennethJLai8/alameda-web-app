import { Component, OnInit, SimpleChanges } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-control-f',
  templateUrl: './control-f.component.html',
  styleUrls: ['./control-f.component.css']
})
export class ControlFComponent implements OnInit{

  homeString:any;
  pattern:string='';
  
  regexFlag:boolean=false;
  matchCaseFlag:boolean=false;
  wholeWordFlag:boolean=false;

  constructor(private http: HttpClient, private router: Router){}

  ngOnInit(): void{
    this.homeString = localStorage.getItem('search');
  }
  sleep(ms:number) {
    return new Promise(resolve => setTimeout(resolve, ms));
  }

  onSubmit()
  {
    this.http.post<any>('https://localhost:7054/api/alameda_web_app_', {pattern: this.pattern, homeString: this.homeString,
    regexFlag: this.regexFlag, matchCaseFlag: this.matchCaseFlag, wholeWordFlag: this.wholeWordFlag}).subscribe(
    _ => this.router.navigate(['/results']));
  }


  ngOnchanges(changes: SimpleChanges)
  {
    console.log(changes);
  }

}

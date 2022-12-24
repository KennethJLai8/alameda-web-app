import {Component} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-results',
  templateUrl: './results.component.html',
  styleUrls: ['./results.component.css']
})
export class ResultsComponent {

  
  returnedArray: string[] = [];
  
  constructor(private http: HttpClient){}

  ngOnInit(): void{
   

    this.http.get<string[]>('https://localhost:7054/api/alameda_web_app_/Bleach').subscribe(data => {this.returnedArray=data;})


    

    
  }

}

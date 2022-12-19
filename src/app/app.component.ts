import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'alameda-web-app';
  //put string
  search: string = "";


  onSubmit()
  {
    //console.log(this.search);
    console.log(this.search);
  }

 


  constructor(){}
  ngOnInit(): void{

  }

  
}

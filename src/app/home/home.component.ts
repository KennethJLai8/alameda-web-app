import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{
   //title = "Home";
   //put string
   search: string = "";

   //what: any[]=[];


   onSubmit()
   {
     //console.log(this.search);
     console.log(this.search);
     localStorage.setItem('search',this.search)
     //this.what.push(this.search)

   }
 
  
 
 
   constructor(){}
   ngOnInit(): void{
 
   }

}

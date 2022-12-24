import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{
  
   search: string = "";

   onSubmit()
   {
     console.log(this.search);
     localStorage.setItem('search',this.search)
   }
 
   constructor(){}
   ngOnInit(): void{
 
   }

}

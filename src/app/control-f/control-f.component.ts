import { Component, OnInit, Input, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-control-f',
  templateUrl: './control-f.component.html',
  styleUrls: ['./control-f.component.css']
})
export class ControlFComponent implements OnInit{

  //@Input() entered: any;
  entered:any;



  constructor(){}
  ngOnInit(): void{
    this.entered = localStorage.getItem('search');
    

  }

  ngOnchanges(changes: SimpleChanges)
  {
    console.log(changes);
  }

}

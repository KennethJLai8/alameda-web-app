import { Component, OnInit, Input, SimpleChanges } from '@angular/core';
import { AlamedaWebAppService } from '../alameda-web-app.service';





@Component({
  selector: 'app-control-f',
  templateUrl: './control-f.component.html',
  styleUrls: ['./control-f.component.css']
})
export class ControlFComponent implements OnInit{

  //@Input() entered: any;
  entered:any;//aka search
  filter:any;
  result:any;//again this needs to be in the results page component. using this here for testing



  constructor(private alamedaWebAppService : AlamedaWebAppService){}

  ngOnInit(): void{
    this.entered = localStorage.getItem('search');

    this.alamedaWebAppService.returnData().subscribe(data => {this.result=data;});//this needs to be in the results page component

    
  }

  onSubmit()
  {

  }

  ngOnchanges(changes: SimpleChanges)
  {
    console.log(changes);
  }

  



}

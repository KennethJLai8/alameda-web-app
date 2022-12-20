import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {Routes, RouterModule} from '@angular/router';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import {MatFormFieldModule} from '@angular/material/form-field'
import {FormsModule, ReactiveFormsModule} from '@angular/forms'
import {MatSelectModule} from '@angular/material/select'
import {HttpClientModule} from '@angular/common/http';
import {MatNativeDateModule} from '@angular/material/core';
import { MatInputModule } from '@angular/material/input';
import { ControlFComponent } from './control-f/control-f.component';
import { HomeComponent } from './home/home.component';
import { MatButtonToggleModule } from '@angular/material/button-toggle';


const appRoutes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'control-f', component: ControlFComponent}
]


@NgModule({
  declarations: [
    AppComponent,
    ControlFComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatFormFieldModule,
    FormsModule,
    ReactiveFormsModule,
    MatSelectModule,
    HttpClientModule,
    MatNativeDateModule,
    MatInputModule,
    MatButtonToggleModule,
    RouterModule.forRoot(appRoutes)

  
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

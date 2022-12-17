import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import {MatFormFieldModule} from '@angular/material/form-field'
import {FormsModule, ReactiveFormsModule} from '@angular/forms'
import {MatSelectModule} from '@angular/material/select'
import {HttpClientModule} from '@angular/common/http';
import {MatNativeDateModule} from '@angular/material/core';
import { MatInputModule } from '@angular/material/input';





@NgModule({
  declarations: [
    AppComponent
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

  
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { TravelCard } from "./travel-components/travel.card";
import { TravelsComponent } from './travels/travels.component';
@NgModule({
  declarations: [
    AppComponent,
    TravelCard,
    TravelsComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

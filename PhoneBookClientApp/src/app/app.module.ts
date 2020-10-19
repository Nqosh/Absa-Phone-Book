import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import { RouterModule } from '@angular/router';
import {AccordionModule} from 'ngx-accordion';
import { SearchfilterPipe } from '../phonebook/searchfilter.pipe';

import { HomeComponent } from '../home/home.component';
import { NavmenuComponent } from '../navmenu/navmenu.component';
import { PhonebookComponent } from '../phonebook/phonebook.component';

import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent,
    NavmenuComponent,
    PhonebookComponent,
    HomeComponent,
    SearchfilterPipe
  ],
  imports: [
    BrowserModule,
    CommonModule,
      ReactiveFormsModule,
      FormsModule,
      HttpClientModule,
      AccordionModule,
      RouterModule.forRoot([
         { path: '', redirectTo: 'home', pathMatch: 'full' },
         { path: 'home', component: HomeComponent },
         { path: 'phone-book', component: PhonebookComponent },
         { path: '**', redirectTo: 'home' }
     ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

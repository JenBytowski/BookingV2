import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { provideHttpClient } from '@angular/common/http';
import { AppComponent } from './app.component';
import { RealEstateListComponent } from './real-estate-list/real-estate-list.component';
import { RealEstateAddComponent } from './real-estate-add/real-estate-add.component';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { RouterLink, RouterOutlet } from '@angular/router';
import { AppRoutingModule } from './app.routes';
import { ErrorDisplayComponent } from './error-display/error-display.component';

@NgModule({
  declarations: [
    AppComponent,
    RealEstateListComponent,
    RealEstateAddComponent,
    ErrorDisplayComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    FormsModule,
    RouterOutlet,
    CommonModule,
    RouterModule
  ],
  providers: [provideHttpClient()],
  bootstrap: [AppComponent]
})
export class AppModule { }

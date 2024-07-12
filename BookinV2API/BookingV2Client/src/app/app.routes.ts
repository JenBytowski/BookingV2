import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AdsComponent } from './ads/ads.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'ads', component: AdsComponent }
];

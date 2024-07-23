import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RealEstateListComponent } from './realeestate-list/realeestate-list.component';
import { RealEstateAddComponent } from './real-estate-add/real-estate-add.component';

const routes: Routes = [
  { path: '', component: RealEstateListComponent },
  { path: 'add', component: RealEstateAddComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

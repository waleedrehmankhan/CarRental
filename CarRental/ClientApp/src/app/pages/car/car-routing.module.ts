import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewCarComponent } from './view-car/view-car.component';
import { AddCarComponent } from './add-car/add-car.component';


const routes: Routes = [
  { path: "view", component: ViewCarComponent },
  { path: "add", component: AddCarComponent },
  { path: "edit/:Id", component: AddCarComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CarRoutingModule { }

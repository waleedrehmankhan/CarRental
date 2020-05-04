import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CarRoutingModule } from './car-routing.module';
import { AddCarComponent } from './add-car/add-car.component';
import { ViewCarComponent } from './view-car/view-car.component';


@NgModule({
  declarations: [AddCarComponent, ViewCarComponent],
  imports: [
    CommonModule,
    CarRoutingModule
  ]
})
export class CarModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CarRoutingModule } from './car-routing.module';
import { AddCarComponent } from './add-car/add-car.component';
import { ViewCarComponent } from './view-car/view-car.component';
import { SharedModule } from '../../shared/shared.module';
import { CarItemComponent } from './car-item/car-item.component';
import { CarAvailabilityComponent } from './car-availability/car-availability.component';


@NgModule({
  declarations: [AddCarComponent, ViewCarComponent, CarItemComponent, CarAvailabilityComponent],
  imports: [
    CommonModule,
    CarRoutingModule,
    SharedModule
  ]
})
export class CarModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BookingRoutingModule } from './booking-routing.module';
import { ViewBookingComponent } from './view-booking/view-booking.component';
import { AddBookingComponent } from './add-booking/add-booking.component';
import { SharedModule } from '../../shared/shared.module';
 


@NgModule({
  declarations: [AddBookingComponent, ViewBookingComponent],
  imports: [
    CommonModule,
    BookingRoutingModule,
    SharedModule,
  ]
})
export class BookingModule {




}

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewBookingComponent } from './view-booking/view-booking.component';
import { AddBookingComponent } from './add-booking/add-booking.component';


const routes: Routes = [

  { path: "view", component: ViewBookingComponent },
  { path: "add", component: AddBookingComponent },
  { path: "add/:Id", component: AddBookingComponent },
  { path: "edit/:Id", component: AddBookingComponent },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BookingRoutingModule { }

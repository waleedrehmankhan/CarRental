import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewCustomerComponent } from './view-customer/view-customer.component';


const routes: Routes = [

  { path: "view", component: ViewCustomerComponent }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomerRoutingModule { }

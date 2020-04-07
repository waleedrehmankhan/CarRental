import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CustomerRoutingModule } from './customer-routing.module';
import { AddCustomerComponent } from './add-customer/add-customer.component';
import { ViewCustomerComponent } from './view-customer/view-customer.component';
import { SharedModule } from '../../shared/shared.module';
import { CrgridComponent } from '../../shared/components/crgrid/crgrid.component';
import { CrselectComponent } from '../../shared/components/crselect/crselect.component';
 





@NgModule({
  declarations: [AddCustomerComponent, ViewCustomerComponent, CrgridComponent, CrselectComponent],
  imports: [
    CommonModule,
    SharedModule,
    CustomerRoutingModule
  ]
})
export class CustomerModule {
 
}

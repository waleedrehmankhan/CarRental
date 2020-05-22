import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PaymentRoutingModule } from './payment-routing.module';
import { ViewPaymentComponent } from './view-payment/view-payment.component';
import { SharedModule } from '../../shared/shared.module';


@NgModule({
  declarations: [ViewPaymentComponent],
  imports: [
    CommonModule,
    PaymentRoutingModule,
    SharedModule
  ]
})
export class PaymentModule { }

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewPaymentComponent } from './view-payment/view-payment.component';
import { VoucherComponent } from './voucher/voucher.component';


const routes: Routes = [
  { path: "view", component: ViewPaymentComponent },
  { path: "voucher/:Id", component: VoucherComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PaymentRoutingModule { }

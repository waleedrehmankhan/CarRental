import { NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules, Router } from '@angular/router';
import { LayoutComponent } from './shared/layout/layout.component';
import { LoginComponent } from './account/login/login.component';
import {
  AuthGuardService as AuthGuard
} from './auth/auth-guard.service';
 import { VoucherComponent } from './pages/payment/voucher/voucher.component';
const routes: Routes = [
  {
    "path": "error",
    "loadChildren": () => import("./pages/error/error.module").then(m => m.ErrorModule),
  },
   
  {
  
    path: 'login', component: LoginComponent
  },
  {
    canActivate: [AuthGuard],
    path: '', component: LayoutComponent,
    children:
      [
        {
          "path": "",
          "loadChildren": () => import("./pages/dashboard/dashboard.module").then(m => m.DashboardModule),
          "data": { "breadcrumb": "Account" }
        },
        {
          "path": "account",
          "loadChildren": () => import("./account/account.module").then(m => m.AccountModule),
          "data": { "breadcrumb": "Account" }
        },
        {
          "path": "customer",
          "loadChildren": () => import("./pages/customer/customer.module").then(m => m.CustomerModule),
          "data": { "breadcrumb": "Customer" }
        },
        {
          "path": "booking",
          "loadChildren": () => import("./pages/booking/booking.module").then(m => m.BookingModule),
          "data": { "breadcrumb": "Booking" }
        },
        {
          "path": "car",
          "loadChildren": () => import("./pages/car/car.module").then(m => m.CarModule),
          "data": { "breadcrumb": "Car" }
        },
        {
          "path": "branch",
          "loadChildren": () => import("./pages/branch/branch.module").then(m => m.BranchModule),
          "data": { "breadcrumb": "Branch" }
        },

        {
          "path": "test",
          "loadChildren": () => import("./pages/test/test.module").then(m => m.TestModule),
          "data": { "breadcrumb": "test" }
        },
        
        {
          "path": "payment",
          "loadChildren": () => import("./pages/payment/payment.module").then(m => m.PaymentModule),
          "data": { "breadcrumb": "payment" }
        },
        
      ]

  },




];;


@NgModule({
  imports: [RouterModule.forRoot(
    routes,
    {
      preloadingStrategy: PreloadAllModules
    }
  )],
  exports: [RouterModule]
})
export class AppRoutingModule {
  constructor(private router: Router) {

  }

} 

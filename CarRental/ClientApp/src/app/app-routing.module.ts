import { NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules, Router } from '@angular/router';
import { LayoutComponent } from './shared/layout/layout.component';
import { LoginComponent } from './account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import {
  AuthGuardService as AuthGuard
} from './auth-guard.service';
const routes: Routes = [
  
  {
    path: 'changepassword', component: RegisterComponent
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

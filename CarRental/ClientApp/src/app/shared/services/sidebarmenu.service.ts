import { Injectable } from '@angular/core';
import { of } from 'rxjs/internal/observable/of';

@Injectable({
  providedIn: 'root'
})
export class SidebarmenuService {

  constructor() { }

  routerConfig: any = [
    { title: "Dashboard", icon: "dashboard", routerLink: "/dashboard" },
    {
      title: "Customer", icon: "smile", children: [
        { title: "Customer Details", icon: "plus", routerLink: "/customer/view" },
        { title: "Add Customer", icon: "plus", routerLink: "/customer/add" },
      ]
    },
    {
      title: "Booking", icon: "dollar", children: [
        { title: "View Bookings", icon: "info", routerLink: "/booking/view" },
        { title: "Add Booking", icon: "plus", routerLink: "/booking/add" },
      ]
    },
    {
      title: "Branch", icon: "dollar", children: [
        { title: "Branch Details", routerLink: "/branch/view" },
        { title: "Branch Users", routerLink: "/branch/user" }
      ]
    },
    {
      title: "Payment", icon: "pay-circle", children: [
        { title: "Payment Details", routerLink: "/payment/view" }
      ]
    },
    {
      title: "Location", icon: "pay-circle", children: [
        { title: "Location Details", routerLink: "/location/view" }
      ]
    }
    
  ];

  getMenu = () => {
    return of(this.routerConfig);
  }
}

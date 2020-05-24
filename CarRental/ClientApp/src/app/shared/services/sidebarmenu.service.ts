import { Injectable } from '@angular/core';
import { of } from 'rxjs/internal/observable/of';

@Injectable({
  providedIn: 'root'
})
export class SidebarmenuService {

  constructor() {
   
  }

  routerConfig: any = [
    { title: "Dashboard", icon: "dashboard", routerLink: "/" },
    {
      title: "Customer", icon: "smile", children: [
        { title: "Customer Details", icon: "plus", routerLink: "/customer/view" },
        { title: "Add Customer", icon: "plus", routerLink: "/customer/add" },
      ]
    },
    {
      title: "Branch", icon: "home", children: [
        { title: "View Branchs", icon: "info", routerLink: "/branch/view" },
        { title: "Add Branch", icon: "plus", routerLink: "/branch/add" },
      ]
    },
    {
      title: "Booking", icon: "dollar", children: [
        { title: "View Bookings", icon: "info", routerLink: "/booking/view" },
        { title: "Add Booking", icon: "plus", routerLink: "/booking/add" },
      ]
    },
    {
      title: "Car", icon: "car", children: [
        { title: "View Car", routerLink: "/car/view" },
        { title: "Add Car", routerLink: "/car/add" }
      ]
    },
    {
      title: "Payment", icon: "pay-circle", children: [
        { title: "Payment Details", routerLink: "/payment/view" }
       
      ]
    },
    {
      title: "User", icon: "pay-circle", children: [
        { title: "Create User", routerLink: "/account/register" }
      ]
    }
    
  ];

  staffRouterConfig: any = [
    { title: "Dashboard", icon: "dashboard", routerLink: "/" },
  
    {
      title: "Booking", icon: "dollar", children: [
        { title: "View Bookings", icon: "info", routerLink: "/booking/view" },
        { title: "Add Booking", icon: "plus", routerLink: "/booking/add" },
      ]
    },
    {
      title: "Car", icon: "car", children: [
        { title: "View Car", routerLink: "/car/view" },
        { title: "Add Car", routerLink: "/car/add" }
      ]
    },
    {
      title: "Payment", icon: "pay-circle", children: [
        { title: "Payment Details", routerLink: "/payment/view" },
       
      ]
    }
    

  ];
  currentuser: any;


  getMenu = (userRole: string) => {
    if (userRole == "Staff") {
      return of (this.staffRouterConfig);
    }
    return of(this.routerConfig);
  }
}

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
      ]
    },
    {
      title: "Branch", icon: "dollar", children: [
        { title: "Branch Details", routerLink: "" },
        { title: "Branch Users", routerLink: "" }
      ]
    },
    {
      title: "Payment", icon: "pay-circle", children: [
        { title: "Payment Details", routerLink: "" }
      ]
    },
    {
      title: "Location", icon: "pay-circle", children: [
        { title: "Location Details", routerLink: "" }
      ]
    }
    
  ];

  getMenu = () => {
    return of(this.routerConfig);
  }
}

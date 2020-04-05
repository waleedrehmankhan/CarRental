import { Component, OnInit, Inject } from '@angular/core';
 

@Component({
  selector: 'app-view-customer',
  templateUrl: './view-customer.component.html',
  styleUrls: ['./view-customer.component.css']
})
export class ViewCustomerComponent implements OnInit {
  
  url:string="customers/getCustomerDetails"
  lstcolumns: string[] = ["CustomerID", "CustomerCode", "FirstName", "MiddleName", "LastName", "EmailAddress", "PhoneNumber", "BirthDate", "LicenseNumber"]
  ngOnInit() {
   
  }
 
  
}

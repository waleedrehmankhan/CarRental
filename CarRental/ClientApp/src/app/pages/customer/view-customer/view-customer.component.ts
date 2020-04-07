import { Component, OnInit, Inject } from '@angular/core';
import { CustomerDto } from '../../../classes/CustomerDto';
import { DataService } from '../../../data.service';

class ToriModel {
  name: string;
  ramLal: string;
}

@Component({
  selector: 'app-view-customer',
  templateUrl: './view-customer.component.html',
  styleUrls: ['./view-customer.component.css']
})
export class ViewCustomerComponent implements OnInit {
  constructor(private _dataService: DataService) {
   
  }
  url: string = "customers/getCustomerDetails"
 
  lstcolumns: string[] = ["CustomerID", "CustomerCode", "FirstName", "MiddleName", "LastName", "EmailAddress", "PhoneNumber", "BirthDate", "LicenseNumber"]
  
  ngOnInit() {
   
  }
 
}

import { Component, OnInit, Inject } from '@angular/core';
import { CustomerDto } from '../../../classes/CustomerDto';
import { DataService } from '../../../data.service';
import { Observable, Subject } from 'rxjs';
import { Router } from '@angular/router';
import { NzMessageService } from 'ng-zorro-antd';

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
  constructor(private _dataService: DataService, private router: Router, private message: NzMessageService) {
   
  }
  url: string = "customers/getCustomerDetails"
  refresh = new Subject<boolean>();
 
  lstcolumns: string[] = [ "CustomerCode", "FirstName", "MiddleName", "LastName", "EmailAddress", "PhoneNumber", "BirthDate", "LicenseNumber"]
  
  ngOnInit() {
   
  }

  deleteClicked(data) {
    console.log("data:", data);
    debugger;
    this._dataService.postData("customers/deleteCustomer", { "CustomerID": data.Id }).subscribe(

      response => {

        this.refresh.next(true);
        this.message.success(response.message.msg, {
          nzDuration: 5000
        });

      }

    );



  }

  editClicked(data: CustomerDto) {
    console.log(data);
    this.router.navigateByUrl(`customer/edit/${data.Id}`)

  }
}

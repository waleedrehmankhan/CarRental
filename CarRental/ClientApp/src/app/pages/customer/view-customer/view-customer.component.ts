import { Component, OnInit, Inject } from '@angular/core';
import { DataService } from '../../../data.service';
import { CustomerDto } from '../../../classes/CustomerDto';
 
 

@Component({
  selector: 'app-view-customer',
  templateUrl: './view-customer.component.html',
  styleUrls: ['./view-customer.component.css']
})
export class ViewCustomerComponent implements OnInit {
  value: string
  data: any

  lstcustomer: CustomerDto[];
  isSpinning: boolean;
  pagenumber: number=1;
  pagesize: number = 10;
  totalcount: number = 0;
    apiBaseUrl: String;
 
  constructor(private _dataService: DataService,
    @Inject("API_BASE_URL") apiBaseUrl: String
  ) {
    this.apiBaseUrl = apiBaseUrl;
  }

  ngOnInit() {
    console.log(this.apiBaseUrl);
   this. getcustomers();
  }

  getcustomers() {

    this.isSpinning = true;
    this._dataService.postData("https://localhost:44341/api/customers/getCustomerDetails", { "pagenumber": this.pagenumber, "pagesize": this.pagesize }).subscribe
      (

        response => {


          this.lstcustomer = response.data.Items;
          this.isSpinning = false;
          this.totalcount = response.data.TotalCount;

          console.log(this.lstcustomer);

        }
      );
  }

  pageSizeChanged(x) {
    this.pagesize = x;
    this.pagenumber = 1;
    this.getcustomers();
  }

  pageIndexChanged(x) {
    this.pagenumber = x;
    this.getcustomers();
  }
}

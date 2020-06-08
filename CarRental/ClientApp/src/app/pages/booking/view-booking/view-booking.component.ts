import { Component, OnInit } from '@angular/core';
import { DataService } from '../../../data.service';
import { Subject } from 'rxjs';
import { NzMessageService } from 'ng-zorro-antd';
import { BookingDto } from '../../../classes/BookingDto';
import { Router } from '@angular/router';
 

@Component({
  selector: 'app-view-booking',
  templateUrl: './view-booking.component.html',
  styleUrls: ['./view-booking.component.css']
})
export class ViewBookingComponent implements OnInit {

  constructor(private _dataService: DataService, private message: NzMessageService, private router: Router) { }


  url: string = "booking/getBookings"
  refresh = new Subject<boolean>();
  lstcolumns: string[] = ["Customer.FirstName:Customer First Name", "FromBranch.BranchName: Pickup Location", "ToBranch.BranchName:Drop Off Location", "FromDate", "ReturnDate","Status"]
  lstactions:string[]=["edit:edit","delete:delete","invoice:money-collect"]
  ngOnInit() {
  }



  deleteClicked(data) {
    console.log("data:", data);
    debugger;
    this._dataService.postData("booking/deleteBooking", { "ID": data.Id }).subscribe(

      response => {

        this.refresh.next(true);
        this.message.success(response.message.msg, {
          nzDuration: 5000
        });

      }

    );

  }

  editClicked(data: BookingDto) {
    console.log(data);
    this.router.navigateByUrl(`booking/edit/${data.Id}`)

  }

  invoiceClicked(data: BookingDto) {
    console.log(data);
    this.router.navigateByUrl(`payment/voucher/${data['Invoice.Id']}`)

  }
}

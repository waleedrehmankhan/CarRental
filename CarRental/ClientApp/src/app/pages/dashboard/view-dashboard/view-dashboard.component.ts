import { Component, OnInit } from '@angular/core';
import { DataService } from '../../../data.service';
import { NzMessageService } from 'ng-zorro-antd';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-view-dashboard',
  templateUrl: './view-dashboard.component.html',
  styleUrls: ['./view-dashboard.component.css']
})
export class ViewDashboardComponent implements OnInit {

  constructor(private _dataService: DataService, private message: NzMessageService, private router: Router) { }
  url: string = "booking/getBookings"
  refresh = new Subject<boolean>();
  lstcolumns: string[] = ["Customer.FirstName: Customer Name", "FromBranch.BranchName: Pickup Location", "ToBranch.BranchName:Drop Off Location", "FromDate:From Date", "ReturnDate:Return Date", "Status: Booking Status"]
  lstactions:string[]=[]
  ngOnInit() {
  }
}

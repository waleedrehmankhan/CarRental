import { Component, OnInit } from '@angular/core';
import { DataService } from '../../../data.service';
import { Router } from '@angular/router';
import { NzMessageService } from 'ng-zorro-antd';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-view-payment',
  templateUrl: './view-payment.component.html',
  styleUrls: ['./view-payment.component.css']
})
export class ViewPaymentComponent implements OnInit {
  constructor(private _dataService: DataService, private router: Router, private message: NzMessageService)
  {

    }
  url: string = "invoice/getInvoiceDetails"
  refresh = new Subject<boolean>();
  ngOnInit() {
  }
  lstcolumns: string[] = ["InvoiceNumber","Customer.FirstName","Amount","IssueDate","DueDate","Description"]
  lstactions:string[]=["edit","delete","dollar"]
}

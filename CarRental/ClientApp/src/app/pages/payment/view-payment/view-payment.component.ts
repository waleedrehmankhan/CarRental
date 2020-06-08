import { Component, OnInit } from '@angular/core';
import { DataService } from '../../../data.service';
import { Router } from '@angular/router';
import { NzMessageService } from 'ng-zorro-antd';
import { Subject } from 'rxjs';
import { InvoiceDto } from '../../../classes/InvoiceDto';

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
  lstcolumns: string[] = ["InvoiceNumber:Invoice No","Customer.FirstName: Customer Name","Amount:Total Due Amount","IssueDate:Issued On","DueDate:Due On","Description"]
   lstactions:string[]=["edit:pay-circle","delete:delete"]

  editClicked(data: InvoiceDto) {
    console.log(data);
    this.router.navigateByUrl(`payment/voucher/${data.Id}`)
  }
 

}

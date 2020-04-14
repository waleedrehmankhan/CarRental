import { Component, OnInit, OnChanges, Input, Inject, Output, EventEmitter } from '@angular/core';
import { DataService } from '../../../data.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-crgrid',
  templateUrl: './crgrid.component.html',
  styleUrls: ['./crgrid.component.css']
})
export class CrgridComponent  implements OnInit {
   
   
  @Input() columns: string[];
  @Input() url: string;
  @Input() refresh: Observable<boolean>;
  @Output() editClick = new EventEmitter<any>();
  @Output() deleteClick = new EventEmitter<any>();


  isSpinning: boolean;
  pagenumber: number = 1;
  pagesize: number = 10;
  totalcount: number = 0;
  records: any;
 

  ngOnInit() {
    console.log(  this.url);
    this.getData();
    this.refresh && this.refresh.subscribe(data => this.getData());

  }
  constructor(private _dataService: DataService 

  ) {
   
  }

  getData() {
    
    this.isSpinning = true;
    this._dataService.postData(this.url, { "pagenumber": this.pagenumber, "pagesize": this.pagesize }).subscribe
      (

        response => {

          this.records = response.data.Items;
          this.isSpinning = false;
          this.totalcount = response.data.TotalCount;
        
        }
      );
  }



  pageSizeChanged(x) {
    this.pagesize = x;
    this.pagenumber = 1;
    this.getData();
  }

  pageIndexChanged(x) {
    this.pagenumber = x;
    this.getData();
  }

  editClicked(data: any) {
    console.log(data);
    this.editClick.next(data);
  }

  deleteClicked(data: any) {
    console.log(data);
    this.deleteClick.next(data);
  }

}

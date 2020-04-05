import { Component, OnInit, OnChanges, Input, Inject } from '@angular/core';
import { DataService } from '../../../data.service';

@Component({
  selector: 'app-crgrid',
  templateUrl: './crgrid.component.html',
  styleUrls: ['./crgrid.component.css']
})
export class CrgridComponent  implements OnInit {
   
  @Input() columns: string[];
  @Input() url: string;

  isSpinning: boolean;
  pagenumber: number = 1;
  pagesize: number = 10;
  totalcount: number = 0;
  records: any;
  apiBaseUrl: String;

  ngOnInit() {
    console.log(  this.url);
    this.getData();

  }
  constructor(private _dataService: DataService,
    @Inject("API_BASE_URL") apiBaseUrl: String

  ) {
    this.apiBaseUrl = apiBaseUrl;
  }

  getData() {
    
    this.isSpinning = true;
    this._dataService.postData(this.apiBaseUrl+this.url, { "pagenumber": this.pagenumber, "pagesize": this.pagesize }).subscribe
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

}

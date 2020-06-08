import { Component, OnInit, OnChanges, Input, Inject, Output, EventEmitter } from '@angular/core';
import { DataService } from '../../../data.service';
import { Observable } from 'rxjs';
interface keyable {
  [key: string]: any;
}

@Component({
  selector: 'app-crgrid',
  templateUrl: './crgrid.component.html',
  styleUrls: ['./crgrid.component.css']
})

export class CrgridComponent  implements OnInit {
   
   
  @Input() columns: string[];
  @Input() actions: string[]=["edit:edit","delete:delete"];
  @Input() url: string;
  @Input() refresh: Observable<boolean>;
  @Output() editClick = new EventEmitter<any>();
  @Output() deleteClick = new EventEmitter<any>();
  @Output() infoClick = new EventEmitter<any>();
  @Output() invoiceClick = new EventEmitter<any>();
  @Output() callAction = new EventEmitter<any>();


  isSpinning: boolean;
  pagenumber: number = 1;
  pagesize: number = 10;
  totalcount: number = 0;
  records: any;
  visible = false;
  searchValue = '';

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
          debugger;
         var itemsarray = new Array();
          for (var v in response.data.Items) {
            debugger;
            itemsarray.push( this.convertIntoOneLevelJson(response.data.Items[v]));
          }
          this.records = itemsarray;
          console.log(itemsarray)
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

  invoiceClicked(data: any) {
    console.log(data);
    this.invoiceClick.next(data);
  }




  callActions(actionName: string, data: any) {
    debugger;
    switch (actionName[0].split(':')[0]) {
     
      case 'edit': return this.editClicked(data);
      case 'delete': return this.deleteClicked(data);
      case 'invoice': return this.invoiceClicked(data);
   
    }
  }
 

  reset(): void {
    this.searchValue = '';
    this.search();
  }

  search(): void {
    this.visible = false;
  //  this.listOfDisplayData = this.listOfData.filter((item: DataItem) => item.name.indexOf(this.searchValue) !== -1);
  }


 convertIntoOneLevelJson = (activity: any, key = ""): any => {
  let response: keyable = {};
  if (
    activity &&
    (activity["constructor"] === "".constructor ||
      activity["constructor"] === (0).constructor)
  ) {
    response[key] = activity;
  } else if (activity === null) {
    response[key] = null;
  } else if (activity && activity["constructor"] === {}.constructor) {
    for (const k in activity) {
      if (k in activity) {
        if (key) {
          response = {
            ...response,
            ...this.convertIntoOneLevelJson(activity[k], `${key}.${k}`)
          };
        } else {
          response = {
            ...response,
            ...this.convertIntoOneLevelJson(activity[k], `${k}`)
          };
        }
      }
    }
  } else if (activity && activity["constructor"] === [].constructor) {
    for (let i = 0; i < activity.length; i++) {
      response = {
        ...response,
        ...this.convertIntoOneLevelJson(activity[i], `${key}[${i}]`)
      };
    }
  } else {
    response[key] = activity;
  }
  return response;
};


}

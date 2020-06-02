import { Component, OnInit, Input } from "@angular/core";
import { DataService } from "../../../data.service";
import { Subject } from "rxjs";
import { NzMessageService } from "ng-zorro-antd";
import { CarDto } from "../../../classes/CarDto";
import { Router } from "@angular/router";
import { FormGroup, FormControl } from "@angular/forms";
interface keyable {
  [key: string]: any;
}
@Component({
  selector: "app-view-car",
  templateUrl: "./view-car.component.html",
  styleUrls: ["./view-car.component.css"],
})
export class ViewCarComponent implements OnInit {
  url: string = "car/getcardetails";
  lstcolumns: string[] = [
    "Model",
    "Mileage",
    "RegistrationNumber",
    "Year",
    "Make",
    "IsAvailable",
    "IsActive",
  ];
  refresh = new Subject<boolean>();
  carItems: CarDto[];
  searchForm: FormGroup

  isSpinning: boolean;
  pagenumber: number = 1;
  pagesize: number = 10;
  totalcount: number =0;
  date =  new Date();
  constructor(
    private _dataService: DataService,
    private message: NzMessageService,
    private router: Router
  ) {}

  ngOnInit() {
    this.searchForm = new FormGroup(
      {
        SearchKey: new FormControl(),
        SearchValue:new FormControl()


      }
    )
    
    this.getCarData();
  }
  getCarData() {
    console.log(this.date)
    this.isSpinning = true;
    this._dataService
      .postData("car/getCarDetails", { "pagenumber": this.pagenumber, "pagesize": this.pagesize, "AvailableDateCheck": this.date})
      .subscribe((response) => {
        console.log(response.data.Items);
        this.totalcount = response.data.TotalCount;
        var itemsarray = new Array();
        //for (var v in response.data.Items) {
        //  debugger;
        //  itemsarray.push(this.convertIntoOneLevelJson(response.data.Items[v]));
          
        //}

        this.carItems = response.data.Items;
        this.isSpinning = false;
        console.log(this.carItems);
      });
  }

  pageSizeChanged(x) {
    this.pagesize = x;
    this.pagenumber = 1;
    this.getCarData();
  }

  pageIndexChanged(x) {
    this.pagenumber = x;
    this.getCarData();
  }


  deleteClicked(data) {
    console.log("data:", data);
    debugger;
    this._dataService
      .postData("car/deleteCar", { Id: data.Id })
      .subscribe((response) => {
        this.refresh.next(true);
        this.message.success(response.message.msg, {
          nzDuration: 5000,
        });
      });
  }

  editClicked(data: CarDto) {
    console.log(data);
    this.router.navigateByUrl(`car/edit/${data.Id}`);
  }

  datechange(data) {
    console.log(this.date);
    this.getCarData();
  }
  submitForm() {}
}

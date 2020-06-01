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
    this.isSpinning = true;
    this._dataService
      .postData("car/getCarDetails", { "pagenumber": this.pagenumber, "pagesize": this.pagesize })
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
              ...this.convertIntoOneLevelJson(activity[k], `${key}.${k}`),
            };
          } else {
            response = {
              ...response,
              ...this.convertIntoOneLevelJson(activity[k], `${k}`),
            };
          }
        }
      }
    } else if (activity && activity["constructor"] === [].constructor) {
      for (let i = 0; i < activity.length; i++) {
        response = {
          ...response,
          ...this.convertIntoOneLevelJson(activity[i], `${key}[${i}]`),
        };
      }
    } else {
      response[key] = activity;
    }
    return response;
  };
}

import { Component, OnInit, Input } from '@angular/core';
import { DataService } from '../../../data.service';
import { Subject } from 'rxjs';
import { NzMessageService } from 'ng-zorro-antd';
import { CarDto } from '../../../classes/CarDto';
import { Router } from '@angular/router';
interface keyable {
  [key: string]: any;
}
@Component({
  selector: 'app-view-car',
  templateUrl: './view-car.component.html',
  styleUrls: ['./view-car.component.css']
})
export class ViewCarComponent implements OnInit {
  url: string = "car/getcardetails"
  lstcolumns: string[] = ["Model", "Mileage", "RegistrationNumber", "Year", "Make", "IsAvailable", "IsActive"]
  refresh = new Subject<boolean>();
  carItems : CarDto[]
  constructor(private _dataService: DataService, private message: NzMessageService, private router: Router) { }

  ngOnInit() {
    this.getCarData();
  }
  getCarData() {

    this._dataService.postData("car/getCarDetails", {  }).subscribe(

      response => {

        console.log(response.data.Items);
        
        var itemsarray = new Array();
        for (var v in response.data.Items) {
          debugger;
          itemsarray.push(this.convertIntoOneLevelJson(response.data.Items[v]));
        }

        this.carItems = itemsarray;
        console.log(this.carItems)


      }
    );

  }
  deleteClicked(data) {
    console.log("data:", data);
    debugger;
    this._dataService.postData("car/deleteCar", { "Id": data.Id }).subscribe(

      response => {

        this.refresh.next(true);
        this.message.success(response.message.msg, {
          nzDuration: 5000
        });
      }
    );
  }

  editClicked(data: CarDto) {
    console.log(data);
    this.router.navigateByUrl(`car/edit/${data.Id}`)

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

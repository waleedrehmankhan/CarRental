import { Component, OnInit, Input } from '@angular/core';
import { CarDto } from '../../../classes/CarDto';
import { Router } from '@angular/router';
import { DataService } from '../../../data.service';
import { NzMessageService } from 'ng-zorro-antd';

@Component({
  selector: 'app-car-item',
  templateUrl: './car-item.component.html',
  styleUrls: ['./car-item.component.css']
})
export class CarItemComponent implements OnInit {

  @Input("car") car: CarDto;
  constructor(private _dataService: DataService, private router: Router, private message: NzMessageService) { }

  ngOnInit() {
  }
  edit(data) {
    console.log(data)
    this.router.navigateByUrl(`car/edit/${data}`)

  }
  delete(data) {
    console.log(data)

    this._dataService.postData("car/deleteCar", { "Id": data }).subscribe(

      response => {

        
        this.message.success(response.message.msg, {
          nzDuration: 5000
        });
      }
    );
  }
}

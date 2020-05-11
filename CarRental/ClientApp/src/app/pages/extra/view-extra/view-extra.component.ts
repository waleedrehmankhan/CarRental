import { Component, OnInit } from '@angular/core';
import { DataService } from '../../../data.service';
import { ExtraDto } from '../../../classes/ExtraDto';

@Component({
  selector: 'app-view-extra',
  templateUrl: './view-extra.component.html',
  styleUrls: ['./view-extra.component.css']
})
export class ViewExtraComponent implements OnInit {
  extraItems:ExtraDto[]
  constructor(private _dataService: DataService) { }

  ngOnInit() {
    this.getExtraData()
  }


  getExtraData() {

    this._dataService.postData("booking/getExtras", {}).subscribe(

      response => {
        debugger;
        console.log(response.data.Items);
        this.extraItems = response.data.Items;

      }
    );

  }
}

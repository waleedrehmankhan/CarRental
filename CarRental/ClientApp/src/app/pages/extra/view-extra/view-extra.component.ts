import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { DataService } from '../../../data.service';
import { ExtraDto } from '../../../classes/ExtraDto';
import { BookingExtraDto } from '../../../classes/BookingExtraDto';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-view-extra',
  templateUrl: './view-extra.component.html',
  styleUrls: ['./view-extra.component.css']
})
export class ViewExtraComponent implements OnInit {
  extraItems: BookingExtraDto[]
  constructor(private _dataService: DataService, private activatedRoute: ActivatedRoute) { }
  @Output("dataChange") dataChange = new EventEmitter<BookingExtraDto[]>();
  
  ngOnInit() {
    const booking_id = this.activatedRoute.snapshot.params.Id;
    this.getExtraData(booking_id);
  }
 

  getExtraData( booking_id) {

    this._dataService.postData("booking/getExtras", { BookingId: booking_id }).subscribe(

      response => {
        debugger;
        console.log(response.data.Items);
        this.extraItems = response.data.Items;

      }
    );

  }

  selectedMap: { [str: string]: BookingExtraDto } = {};
  dataSelected({
    extra, checked
  }) {
    console.log(extra, checked);
    if (extra) {
      if (!checked) {
         delete this.selectedMap[extra['ExtraId']];
      } else {
        this.selectedMap[extra['ExtraId']] = extra;
      }
    }

    const selectedItems: BookingExtraDto[] = [];
    for (let key in this.selectedMap) {
      selectedItems.push(this.selectedMap[key]);
    }

    this.dataChange.next(selectedItems);

  }
}

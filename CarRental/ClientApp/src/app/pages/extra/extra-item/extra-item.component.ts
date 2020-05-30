import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
 
import { BookingExtraDto } from '../../../classes/BookingExtraDto';

@Component({
  selector: 'app-extra-item',
  templateUrl: './extra-item.component.html',
  styleUrls: ['./extra-item.component.css']
})
export class ExtraItemComponent implements OnInit {
  @Input("extra") extra: BookingExtraDto;

  @Output("select") select = new EventEmitter<{ extra: BookingExtraDto, checked: boolean }>(); 
  count: number = this.extra&& this.extra.Count;
  checked = false;
  isDisabled: boolean;

  constructor() { }

  ngOnInit() {

    if ((this.extra && this.extra.Count) !== 0) {
      this.checked = true;
      this.selected();
    }
    this.isDisabled = (this.extra && (this.extra.PriceType == 1)) ? false : true

    console.log(this.extra.PriceType);
    console.log((this.extra && (this.extra.PriceType == 1)) ? false : true)
  }

  selected() {
    const extra = { ...this.extra };
 
    this.select.emit({
      extra, checked: this.checked
     });
  }


}

import { Component, OnInit, Input, forwardRef } from '@angular/core';
import { DataService } from '../../../data.service';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

@Component({
  selector: 'crselect',
  templateUrl: './crselect.component.html',
  styleUrls: ['./crselect.component.css'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => CrselectComponent),
      multi: true
    }
  ]
})
export class CrselectComponent implements OnInit, ControlValueAccessor {
   
  @Input() url: string;
  @Input() key: string;
  @Input() value: string;
  @Input() disabled: boolean=false;
  @Input() defaultvalue: string ;
  selectedValue = null;
    changeFn: any;
    touchChangeFn: any;
    isDisabled: boolean;
  constructor(private _dataService: DataService) { }

  items: any;

  ngOnInit() {
    console.log(this.url);
   
    this.getSelectData();
   
  }



  getSelectData() {
    this._dataService.postData(this.url, {}).subscribe
      (

        response => {

          console.log(response);
          this.items = response.data.Items;
          //this.selectedValue = response.data.Items[0].Id;
          if (this.defaultvalue) {
            this.selectedValue = this.defaultvalue;

          }
           
          this.modelChanged();

        }
      );

  }

  modelChanged() {
    this.changeFn(this.selectedValue);
    this.touchChangeFn(this.selectedValue);
  }

  // anglar le value value
  writeValue(obj: any): void {
    this.selectedValue = obj;
  }

  registerOnChange(fn: any): void {
    this.changeFn = fn;
  }

  registerOnTouched(fn: any): void {
    this.touchChangeFn = fn;
  }

  setDisabledState?(isDisabled: boolean): void {
    this.isDisabled = isDisabled;
  }

}

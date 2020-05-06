import { Component, OnInit, Input } from '@angular/core';
import { CarDto } from '../../../classes/CarDto';

@Component({
  selector: 'app-car-item',
  templateUrl: './car-item.component.html',
  styleUrls: ['./car-item.component.css']
})
export class CarItemComponent implements OnInit {

  @Input("car") car: CarDto;
  constructor() { }

  ngOnInit() {
  }

}

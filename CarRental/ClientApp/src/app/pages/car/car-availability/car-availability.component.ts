import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-car-availability',
  templateUrl: './car-availability.component.html',
  styleUrls: ['./car-availability.component.css']
})
export class CarAvailabilityComponent implements OnInit {
  @Input() eventData:  []
 

  constructor() { }

  ngOnInit() {
  }

  getColor(data: {time: string, IsAvailable: boolean}) {
    return data.IsAvailable ? 'green' : '#999';
  }

}

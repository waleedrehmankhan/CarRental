import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-car-availability',
  templateUrl: './car-availability.component.html',
  styleUrls: ['./car-availability.component.css']
})
export class CarAvailabilityComponent implements OnInit {
  @Input() eventData:  []
 

  constructor(private router: Router) { }

  ngOnInit() {
  }

  getColor(data: {time: string, IsAvailable: boolean}) {
    return data.IsAvailable ? 'green' : '#999';
  }

  gotobooking(data) {
    console.log(data)
    this.router.navigate([`booking/add/${data.CarId}`, {
      "CarId": data.CarId 
    }]);
       }

}

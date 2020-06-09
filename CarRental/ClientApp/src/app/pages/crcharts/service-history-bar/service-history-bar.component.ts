import { Component, OnInit } from '@angular/core';
import { DataService } from '../../../data.service';

@Component({
  selector: 'app-service-history-bar',
  templateUrl: './service-history-bar.component.html',
  styleUrls: ['./service-history-bar.component.css']
})
export class ServiceHistoryBarComponent implements OnInit {
  response: any;
  constructor(private _dataService: DataService) { }
  public barChartOptions = {
    scaleShowVerticalLines: false,
    responsive: true
  };
  public barChartLabels = [];
  public barChartType = 'bar';
  public barChartLegend = true;
  public barChartData = [
    //{ data: [65, 59, 80, 81, 56, 55, 40, 80, 81, 56, 55, 40], label: 'Tyre Replacement' },
    //{ data: [28, 48, 40, 19, 86, 27, 90, 40, 19, 86, 27, 90], label: 'Mobil Change' },
    //{ data: [28, 48, 40, 19, 81, 26, 90, 40, 19, 80, 27, 90], label: 'Fuel Fill' },
    //{ data: [28, 48, 40, 19, 86, 27, 90, 40, 19, 81, 27, 90], label: 'Other' }
 
  ];

  getMonthlyExpenseData() {
    
    this._dataService
      .postData("car/getExpenseByTypeMonthly", {})
      .subscribe((response) => {
        debugger;
        console.log("bar", response)
        this.response = response;
        this.barChartData = response.barChartData;
        this.barChartType = response.barChartType;
        this.barChartLegend = response.barChartLegend;
        this.barChartLabels = response.barChartLabels;
        

      
      });
  }


  ngOnInit() {
   this. getMonthlyExpenseData()
  }

}

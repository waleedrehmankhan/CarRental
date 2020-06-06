import { Component, OnInit } from '@angular/core';
import { ChartType, ChartOptions } from 'chart.js';
import { SingleDataSet, Label, monkeyPatchChartJsLegend, monkeyPatchChartJsTooltip } from 'ng2-charts';
@Component({
  selector: 'app-branch-income-pie',
  templateUrl: './branch-income-pie.component.html',
  styleUrls: ['./branch-income-pie.component.css']
})
export class BranchIncomePieComponent implements OnInit {

  constructor() {

    monkeyPatchChartJsTooltip();
    monkeyPatchChartJsLegend();}

  ngOnInit() {
  }
  public pieChartOptions: ChartOptions = {
    responsive: true,
  };
  public pieChartLabels: Label[] = [['Download', 'Sales'], ['In', 'Store', 'Sales'], 'Mail Sales'];
  public pieChartData: SingleDataSet = [300, 500, 100];
  public pieChartType: ChartType = 'pie';
  public pieChartLegend = true;
  public pieChartPlugins = [];

}

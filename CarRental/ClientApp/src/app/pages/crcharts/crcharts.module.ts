import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CrchartsRoutingModule } from './crcharts-routing.module';
import { BranchIncomePieComponent } from './branch-income-pie/branch-income-pie.component';
import { ChartsModule } from 'ng2-charts';
import { ServiceHistoryBarComponent } from './service-history-bar/service-history-bar.component';


@NgModule({
  declarations: [BranchIncomePieComponent, ServiceHistoryBarComponent],
  imports: [
    CommonModule,
    ChartsModule,
    CrchartsRoutingModule
  ],
  exports: [BranchIncomePieComponent, ServiceHistoryBarComponent]
})
export class CrchartsModule { }

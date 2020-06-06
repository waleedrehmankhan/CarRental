import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CrchartsRoutingModule } from './crcharts-routing.module';
import { BranchIncomePieComponent } from './branch-income-pie/branch-income-pie.component';
import { ChartsModule } from 'ng2-charts';


@NgModule({
  declarations: [BranchIncomePieComponent],
  imports: [
    CommonModule,
    ChartsModule,
    CrchartsRoutingModule
  ],
  exports: [BranchIncomePieComponent]
})
export class CrchartsModule { }

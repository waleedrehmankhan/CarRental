import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { ViewDashboardComponent } from './view-dashboard/view-dashboard.component';
import { SharedModule } from '../../shared/shared.module';
import { CrchartsModule } from '../crcharts/crcharts.module';
 
@NgModule({
  declarations: [ViewDashboardComponent],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    SharedModule,
    CrchartsModule
  ]
})
export class DashboardModule { }

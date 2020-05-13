import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { ViewDashboardComponent } from './view-dashboard/view-dashboard.component';


@NgModule({
  declarations: [ViewDashboardComponent],
  imports: [
    CommonModule,
    DashboardRoutingModule
  ]
})
export class DashboardModule { }

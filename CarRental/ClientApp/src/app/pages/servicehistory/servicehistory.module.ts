import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ServicehistoryRoutingModule } from './servicehistory-routing.module';
import { AddHistoryComponent } from './add-history/add-history.component';
import { ViewHistoryComponent } from './view-history/view-history.component';
import { SharedModule } from '../../shared/shared.module';


@NgModule({
  declarations: [AddHistoryComponent, ViewHistoryComponent],
  imports: [
    CommonModule,
    SharedModule,
    ServicehistoryRoutingModule
  ]
})
export class ServicehistoryModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ExtraRoutingModule } from './extra-routing.module';
import { ExtraItemComponent } from './extra-item/extra-item.component';
import { ViewExtraComponent } from './view-extra/view-extra.component';


@NgModule({
  declarations: [ExtraItemComponent, ViewExtraComponent],
  imports: [
    CommonModule,
    ExtraRoutingModule
  ]
})
export class ExtraModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { CrselectComponent } from './components/crselect/crselect.component';
import { CrgridComponent } from './components/crgrid/crgrid.component';
import { ViewExtraComponent } from '../pages/extra/view-extra/view-extra.component';
import { ExtraItemComponent } from '../pages/extra/extra-item/extra-item.component';
 
 


@NgModule({
  declarations: [CrselectComponent,CrgridComponent,ViewExtraComponent,ExtraItemComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgZorroAntdModule,

  ],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    CrselectComponent,
    CrgridComponent,
    ViewExtraComponent,
    ExtraItemComponent
  ],
  
})
export class SharedModule { }

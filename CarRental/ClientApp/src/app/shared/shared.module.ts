import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { CrselectComponent } from './components/crselect/crselect.component';
import { CrgridComponent } from './components/crgrid/crgrid.component';
 
 


@NgModule({
  declarations: [CrselectComponent,CrgridComponent],
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
    CrgridComponent
  ],
  
})
export class SharedModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BranchRoutingModule } from './branch-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { AddBranchComponent } from './add-branch/add-branch.component';
import { ViewBranchComponent } from './view-branch/view-branch.component';


@NgModule({
  declarations: [AddBranchComponent, ViewBranchComponent],
  imports: [
    CommonModule,
    BranchRoutingModule,
    SharedModule
  ]
})
export class BranchModule { }

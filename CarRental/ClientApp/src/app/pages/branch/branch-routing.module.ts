import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewBranchComponent } from './view-branch/view-branch.component';
import { AddBranchComponent } from './add-branch/add-branch.component';


const routes: Routes = [
  { path: "view", component: ViewBranchComponent },
  { path: "add", component: AddBranchComponent },
  { path: "edit/:Id", component: AddBranchComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BranchRoutingModule { }

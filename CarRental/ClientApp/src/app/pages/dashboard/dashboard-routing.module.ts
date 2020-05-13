import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewDashboardComponent } from './view-dashboard/view-dashboard.component';


const routes: Routes = [
  { path: "", component: ViewDashboardComponent },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }

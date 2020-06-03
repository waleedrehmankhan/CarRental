import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddHistoryComponent } from './add-history/add-history.component';


const routes: Routes = [
  { path: "add", component: AddHistoryComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ServicehistoryRoutingModule { }

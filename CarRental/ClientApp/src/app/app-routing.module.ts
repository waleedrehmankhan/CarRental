import { NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules, Router } from '@angular/router';
import { LayoutComponent } from './shared/layout/layout.component';
 

const routes: Routes = [
  
  {
 
    path: '', component: LayoutComponent,
    children:
      [
        {
          "path": "customer",
          "loadChildren": () => import("./pages/customer/customer.module").then(m => m.CustomerModule),
          "data": { "breadcrumb": "Customer" }
        },
      ]

  },




];;


@NgModule({
  imports: [RouterModule.forRoot(
    routes,
    {
      preloadingStrategy: PreloadAllModules
    }
  )],
  exports: [RouterModule]
})
export class AppRoutingModule {
  constructor(private router: Router) {

  }

} 

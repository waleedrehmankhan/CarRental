import { NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules, Router } from '@angular/router';
import { LayoutComponent } from './shared/layout/layout.component';
 

const routes: Routes = [
  
  {
 
    path: '', component: LayoutComponent,
    children:
      []

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

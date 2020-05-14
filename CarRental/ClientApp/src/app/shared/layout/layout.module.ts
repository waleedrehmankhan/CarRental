import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layout.component';
import { HeaderComponent } from './header/header.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { ItemComponent } from './sidebar/item/item.component';
import { NzLayoutModule, NzIconModule, NzDropDownModule, NzSpinModule, NzBreadCrumbModule } from 'ng-zorro-antd';
import { IconsProviderModule } from '../../icons-provider.module';
 
import { RouterModule } from '@angular/router';
import { RemoveHostDirective } from './sidebar/remove-host.directive';
 

@NgModule({
  declarations: [LayoutComponent, HeaderComponent, SidebarComponent, ItemComponent, RemoveHostDirective],
  imports: [
    CommonModule,
    RouterModule,
    NzSpinModule,
    NzLayoutModule,
    IconsProviderModule,
    NzDropDownModule,
    NzIconModule,
    NzBreadCrumbModule,

  ],
  providers: []
})
export class LayoutModule { }

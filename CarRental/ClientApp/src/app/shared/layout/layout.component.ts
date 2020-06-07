import { Component, OnInit, AfterViewChecked, AfterViewInit, ChangeDetectorRef } from '@angular/core';
import { SidebarmenuService } from '../services/sidebarmenu.service';
import { TokenInterceptor } from '../../interceptor/token.interceptor';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent implements OnInit, AfterViewInit {
   
   

  isCollapsed: Boolean = false;
  branchname: string;
  sidebarConfig: any;
  isSpinning: boolean = false
  constructor(private _menuService: SidebarmenuService, private interceptor: TokenInterceptor, private cdRef: ChangeDetectorRef) { }

  ngOnInit() {
    let currentuser = sessionStorage.getItem("current_user") && JSON.parse(sessionStorage.getItem("current_user"));
    console.log(currentuser);
    this._menuService.getMenu(currentuser.UserRole).subscribe(menu => this.sidebarConfig = menu)
    this.branchname = currentuser.BranchName;
  }

  ngAfterViewInit() {
    //console.log("test",this.interceptor.loading);
    this.interceptor.loading.subscribe(d => {
      console.log("loading: ", d);
      this.isSpinning = d;
      this.cdRef.detectChanges();
    });
  }
}

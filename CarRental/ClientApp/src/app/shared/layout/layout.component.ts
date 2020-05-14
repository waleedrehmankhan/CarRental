import { Component, OnInit, AfterViewChecked, AfterViewInit } from '@angular/core';
import { SidebarmenuService } from '../services/sidebarmenu.service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent implements OnInit, AfterViewInit {
   
  ngAfterViewInit(): void {

  }

  isCollapsed: Boolean = false;
  sidebarConfig: any;
  constructor(private _menuService: SidebarmenuService) { }

  ngOnInit() {
    let currentuser = sessionStorage.getItem("current_user") && JSON.parse(sessionStorage.getItem("current_user"));
    console.log(currentuser);
    this._menuService.getMenu(currentuser.UserRole).subscribe(menu => this.sidebarConfig = menu)
  }

}

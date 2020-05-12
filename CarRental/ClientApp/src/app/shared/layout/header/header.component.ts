import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RegisterUserDto } from '../../../classes/ApplicationUserDto';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  userMenu: any[];
  user: RegisterUserDto;
  constructor(private router: Router) {

    this.user = JSON.parse( sessionStorage.getItem("current_user"));
  }

  ngOnInit() {
    this.userMenu = [
      { title: "Log Out", onClick: (e) => { sessionStorage.clear(); this.router.navigate(['login', {}]); } },
      
    ];
  }

}

import { Component, OnInit,Input } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {

  @Input() isCollapsed;
  @Input() sidebarConfig: any[] = [];
  ngOnInit() {
    console.log(this.isCollapsed);
  }

}


 

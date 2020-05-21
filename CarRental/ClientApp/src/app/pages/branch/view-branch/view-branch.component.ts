import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { BranchDto } from 'src/app/classes/BranchDto';

@Component({
  selector: 'app-view-branch',
  templateUrl: './view-branch.component.html',
  styleUrls: ['./view-branch.component.css']
})
export class ViewBranchComponent implements OnInit {

  url: string = "branch/getBranchDetails"
  refresh = new Subject<boolean>();
  lstcolumns: string[] = [ "BranchName", "PhoneNumber", "Suburb" ]


  constructor() { }

  ngOnInit() {
  }

  deleteClicked(data) {
    console.log("data:", data);


  }

  editClicked(data: BranchDto) {
    console.log(data);
  }

}

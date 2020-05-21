import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { BranchDto } from 'src/app/classes/BranchDto';
import { DataService } from 'src/app/data.service';
import { Router } from '@angular/router';
import { NzMessageService } from 'ng-zorro-antd';

@Component({
  selector: 'app-view-branch',
  templateUrl: './view-branch.component.html',
  styleUrls: ['./view-branch.component.css']
})


export class ViewBranchComponent implements OnInit {

  url: string = "branch/getBranchDetails"
  refresh = new Subject<boolean>();
  lstcolumns: string[] = [ "BranchName", "PhoneNumber", "Suburb" ]


  constructor(private _dataService: DataService, private router: Router, private message: NzMessageService) {
   
  }

  ngOnInit() {
  }

  deleteClicked(data) {
    console.log("data:", data);
    this._dataService.postData("branch/deleteBranch", { "Id": data.Id }).subscribe(

      response => {

        this.refresh.next(true);
        this.message.success(response.message.msg, {
          nzDuration: 5000
        });

      }

    );


  }

  editClicked(data: BranchDto) {
    console.log(data);
    this.router.navigateByUrl(`branch/edit/${data.Id}`)
  }

}

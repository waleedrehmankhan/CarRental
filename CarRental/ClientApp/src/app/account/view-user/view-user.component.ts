import { Component, OnInit } from "@angular/core";
import { DataService } from "src/app/data.service";
import { Router } from "@angular/router";
import { NzMessageService } from "ng-zorro-antd";
import { Subject } from "rxjs";
import { UserDto } from 'src/app/classes/UserDto';
@Component({
  selector: "app-view-user",
  templateUrl: "./view-user.component.html",
  styleUrls: ["./view-user.component.css"],
})
export class ViewUserComponent implements OnInit {
  lstactions:string[]=["edit:edit"]
  constructor(
    private _dataService: DataService,
    private router: Router,
    private message: NzMessageService
  ) {}

  url: string = "account/getUserDetails";
  refresh = new Subject<boolean>();

  lstcolumns: string[] = [
    "FirstName",
    "LastName",
    "Email",
    "Username",
    "PhoneNumber",
  ];

  deleteClicked(data) {
    console.log("data:", data);
    debugger;
    this._dataService
      .postData("account/deleteUser", { Email: data.Email })
      .subscribe((response) => {
        this.refresh.next(true);
        this.message.success(response.message.msg, {
          nzDuration: 5000,
        });
      });
  }

  editClicked(data: UserDto) {
     console.log(data);
     this.router.navigateByUrl(`account/edit/${data.Id}`)
   }

  ngOnInit() {}
}

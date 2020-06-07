import { Component, OnInit } from "@angular/core";
import {
  FormBuilder,
  Validators,
  FormGroup,
  ReactiveFormsModule,
  FormControl,
} from "@angular/forms";
import { DataService } from "src/app/data.service";
import { RegisterUserDto } from "src/app/classes/RegisterUserDto";
import { NzMessageService } from "ng-zorro-antd";

@Component({
  selector: "app-register",
  templateUrl: "./register.component.html",
  styleUrls: ["./register.component.css"],
})
export class RegisterComponent implements OnInit {
  errors: string[];
  registerForm: FormGroup;
  registerDto = new RegisterUserDto();
  userRolesUrl: string = "account/roles";
  BranchUrl: string = "branch/getBranchDetails";
  current_user = JSON.parse(sessionStorage.getItem("current_user"))
  BranchId = this.current_user.BranchId;
  disabled: boolean = this.current_user.BranchId!=3

  constructor(
    private fb: FormBuilder,
    private _dataService: DataService,
    private message: NzMessageService
  ) {
    this.registerForm = new FormGroup({
      Email: new FormControl(),
      Username: new FormControl(),
      Password: new FormControl(),
      FirstName: new FormControl(),
      LastName: new FormControl(),
      UserRole: new FormControl(),
      BranchId: new FormControl()
    });
    this.registerDto.BranchId = this.BranchId;
    console.log("test:", this.BranchId)
  }

  ngOnInit() {
    this.registerForm.reset();
  }

  submitForm = () => {
    this.errors = [];
    if (this.registerForm.valid) {
      console.log(this.registerForm);
      debugger;

      //object
      this.registerDto.Email = this.registerForm.value.Email;
      this.registerDto.Username = this.registerForm.value.Username;
      this.registerDto.Password = this.registerForm.value.Password;
      this.registerDto.FirstName = this.registerForm.value.FirstName;
      this.registerDto.LastName = this.registerForm.value.LastName;
      this.registerDto.UserRole = this.registerForm.value.UserRole;
      this.registerDto.BranchId = this.registerForm.value.BranchId;

      console.log(this.registerDto);

      debugger;
      this._dataService
        .postData("account/register", this.registerDto)
        .subscribe((res: any) => {
          console.log(res);
          //if(res.succeded){
          //  this.registerForm.reset();
          //} else {
          //  res.errors.forEach(element => {
          //    switch(element.code) {
          //      case 'DuplicateUserName':
          //        this.message.error("Username is already taken." , {
          //          nzDuration: 5000
          //        });
          //        break;
          //      default:
          //        this.message.error(element.description , {
          //          nzDuration: 5000
          //        });
          //        break;
          //    }
          //  });
          //}

          if (res.data && res.data.message.msgCode == -2) {
            let validationErrorDictionary = res.data.message.msg;
            debugger;
            console.log(validationErrorDictionary);

            setTimeout(() => {
              for (var fieldName in validationErrorDictionary) {
                this.registerForm.markAsDirty();
                this.registerForm.markAllAsTouched();
                if (validationErrorDictionary.hasOwnProperty(fieldName)) {
                  debugger;
                  this.errors.push(validationErrorDictionary[fieldName]);
                  if (this.registerForm.get(fieldName)) {
                    this.registerForm.get(fieldName).setErrors({
                      invalid: true,
                      errors: validationErrorDictionary[fieldName],
                    });
                    this.registerForm.get(fieldName).markAsTouched();
                    this.registerForm.get(fieldName).markAsDirty();

                    console.log(validationErrorDictionary[fieldName]);
                  } else {
                    debugger;
                    // if we have cross field validation then show the validation error at the top of the screen
                    this.errors.push(validationErrorDictionary[fieldName]);
                  }
                }
              }
            }, 100);
          } else if (res.message.msgCode == "1") {
            this.message.success(res.message.msg, {
              nzDuration: 5000,
            });
            this.registerForm.reset();
          } else if (res.message && res.message.msgCode == -3) {
            debugger;
            console.log("hello");
            this.errors.push(res.message.msg);
            this.message.error(res.message.msg, {
              nzDuration: 5000,
            });
          } else {
            this.errors.push("something went wrong!");
          }
          this.registerForm.markAsDirty();
        });
    }
  };
}

import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup, ReactiveFormsModule, FormControl } from '@angular/forms';
import { DataService } from 'src/app/data.service';
import { RegisterUserDto } from 'src/app/classes/RegisterUserDto';
import { NzMessageService } from 'ng-zorro-antd';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;
  registerDto = new RegisterUserDto();
  userRolesUrl: string = "account/roles";

  constructor(private fb: FormBuilder, private _dataService: DataService, private message: NzMessageService) {
    this.registerForm = new FormGroup({
      Email: new FormControl(),
      Password: new FormControl(),
      FirstName: new FormControl(),
      LastName: new FormControl(),
      UserRole: new FormControl()
   });
   }

  ngOnInit() {
    this.registerForm.reset();
  }

  submitForm = ( ) => {

    if (this.registerForm.valid) {
      console.log(this.registerForm)
      debugger;

      //object
      this.registerDto.Email =this.registerForm.value.Email
      this.registerDto.Password =this.registerForm.value.Password
      this.registerDto.FirstName =this.registerForm.value.FirstName
      this.registerDto.LastName =this.registerForm.value.LastName
      this.registerDto.UserRole =this.registerForm.value.UserRole
      
      console.log(this.registerDto);

      debugger;
      this._dataService.postData("account/register", this.registerDto).subscribe(
        (res: any) => {
          if(res.succeded){
            this.registerForm.reset();
          } else {
            res.errors.forEach(element => {
              switch(element.code) {
                case 'DuplicateUserName':
                  this.message.error("Username is already taken." , {
                    nzDuration: 5000
                  });
                  break;
                default:
                  this.message.error(element.description , {
                    nzDuration: 5000
                  });
                  break;
              }
            });
          }
        },
          err => {
            console.log(err);
          }
      );
    }
  }

}

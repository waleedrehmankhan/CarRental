import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';
import { LoginUserDto } from 'src/app/classes/LoginUserDto';
import { DataService } from 'src/app/data.service';
import { NzMessageService } from 'ng-zorro-antd';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  loginDto = new LoginUserDto();

  constructor(private fb: FormBuilder, private _dataService: DataService, private message: NzMessageService) {
    this.loginForm = new FormGroup({
      Email: new FormControl(),
      Password: new FormControl()
   });
   }

   ngOnInit() {
    this.loginForm.reset();
  }

  submitForm = ( ) => {

    if (this.loginForm.valid) {
      console.log(this.loginForm)
      debugger;

      //object
      this.loginDto.Email =this.loginForm.value.Email
      this.loginDto.Password =this.loginForm.value.Password
      
      console.log(this.loginDto);

      debugger;
      this._dataService.postData("account/login", this.loginDto).subscribe(
        (res: any) => {
          if(res.succeded){
            localStorage.setItem('token',res.token);
            console.log(localStorage)
            this.loginForm.reset();
          } 
        },
          err => {
            console.log(err);
            if (err.status == 400) {
              this.message.error("Incorrect Username or Password!" , {
                nzDuration: 5000
              });
            }
          }
      );
    }
  }

}

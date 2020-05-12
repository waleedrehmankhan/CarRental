import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';
import { LoginUserDto } from 'src/app/classes/LoginUserDto';
import { DataService } from 'src/app/data.service';
import { NzMessageService } from 'ng-zorro-antd';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  return: string = '';
  loginDto = new LoginUserDto();
  errors: string[];


  constructor(private fb: FormBuilder, private _dataService: DataService, private message: NzMessageService, private router: Router, private route: ActivatedRoute) {
    this.loginForm = new FormGroup({
      Email: new FormControl(),
      Password: new FormControl()
   });
   }

   ngOnInit() {
     this.route.queryParams
       .subscribe(params => this.return = params['return'] || '/car/view');
    this.loginForm.reset();
  }

  submitForm = ( ) => {
    this.errors = [];
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
          debugger;
          //if(res.succeded){
          //  localStorage.setItem('token',res.token);
          //  console.log(localStorage)
          //  this.loginForm.reset();
          //}
          if (res.data.Items) {
            console.log(res.data.Items[0]);
            var user = res.data.Items[0];
            sessionStorage.setItem('current_user', JSON.stringify(user));

           

            if (res.message.msgCode == "1") {
              this.message.success(res.message.msg, {
                nzDuration: 3000
              });
              this.router.navigateByUrl(this.return);
            }
            else {
              this.message.error(res.message.msg, {
                nzDuration: 5000
              });

            }

          }
          if (res.data && res.data.message.msgCode == -2) {

            let validationErrorDictionary = res.data.message.msg;
            debugger;
            console.log(validationErrorDictionary);

            setTimeout(() => {

              for (var fieldName in validationErrorDictionary) {
                this.loginForm.markAsDirty();
                this.loginForm.markAllAsTouched();
                if (validationErrorDictionary.hasOwnProperty(fieldName)) {
                  this.errors.push(validationErrorDictionary[fieldName]);
                  if (this.loginForm.controls[fieldName]) {
                    // integrate into angular's validation if we have field validation
                    // this.customerForm.controls[fieldName].setErrors({ invalid: true });

                    this.loginForm.get(fieldName).setErrors({ invalid: true, errors: validationErrorDictionary[fieldName] });
                    this.loginForm.get(fieldName).markAsTouched();
                    this.loginForm.get(fieldName).markAsDirty();



                    console.log(validationErrorDictionary[fieldName]);
                  }

                  else {
                    debugger;
                    // if we have cross field validation then show the validation error at the top of the screen
                    this.errors.push(validationErrorDictionary[fieldName]);
                  }
                }
              }



            }, 100);


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

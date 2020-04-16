import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { CustomerDto } from '../../../classes/CustomerDto';
import { DataService } from '../../../data.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NzMessageService } from 'ng-zorro-antd';
 


@Component({
  selector: 'add-customer',
  templateUrl: './add-customer.component.html',
  styleUrls: ['./add-customer.component.css']
})
export class AddCustomerComponent implements OnInit {
   
  errors: string[]
  customerForm: FormGroup;
  successfulSave: boolean;
  constructor(private fb: FormBuilder, private _dataService: DataService, private activatedRoute: ActivatedRoute, private router: Router, private message: NzMessageService) {
  }

  customerDto = new CustomerDto();
  membershipurl: string = "membership/getMemberShip";

  ngOnInit(): void {

    const customerID = this.activatedRoute.snapshot.params.CustomerID;

    customerID && this._dataService.postData("customers/getCustomerDetails", { "CustomerID": customerID }).subscribe
      (

        response => {
          const [customer] = response.data.Items;
          this.customerForm.patchValue(customer);

        }
      );

    this.customerForm = this.fb.group({
      CustomerID: [customerID],
      CustomerCode: "",
      FirstName: "",
      LastName: "",
      EmailAddress: [""],
      PhoneNumber: [""],
      LicenseNumber: [""],
      MembershipTypeId: [""],
      BirthDate: [null],
    });
    console.log(this.customerForm);    
    this.errors = [];
  }

  submitForm = ( ) => {
    if (this.customerForm.valid) {

      console.log(this.customerForm.value.MembershipTypeId);
      this.customerDto = this.mapValues(this.customerForm.value);
      this.errors = [];
      console.log(this.customerDto);
      this._dataService.postData("customers/createOrUpdateCustomer", this.customerDto).subscribe(

        response => {

          console.log(response);
          console.log( );

          
          if (response.data &&response.data.message.msgCode == -2)
          {

            let validationErrorDictionary = response.data.message.msg;
            debugger;
            console.log(validationErrorDictionary);

            setTimeout(() => {

              for (var fieldName in validationErrorDictionary) {
                this.customerForm.markAsDirty();
                this.customerForm.markAllAsTouched();
                if (validationErrorDictionary.hasOwnProperty(fieldName)) {
                  this.errors.push(validationErrorDictionary[fieldName]);
                  if (this.customerForm.controls[fieldName]) {
                    // integrate into angular's validation if we have field validation
                    // this.customerForm.controls[fieldName].setErrors({ invalid: true });
                     
                    this.customerForm.get(fieldName).setErrors({ invalid: true, errors: validationErrorDictionary[fieldName] });
                      this.customerForm.get(fieldName).markAsTouched();
                    this.customerForm.get(fieldName).markAsDirty();
                     


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
          else if (response.message.msgCode =="1")
          {
            this.successfulSave = true;
             
            this.message.success(response.message.msg , {
              nzDuration: 5000
            });
            this.router.navigateByUrl("customer/view")
          }
          else if (response.data && response.data.message.msgCode == -3) {
            debugger;
            console.log('hello');
            this.errors.push(response.data.message.msg);

          }
          else {
            this.errors.push("something went wrong!");



          }
          this.customerForm.markAsDirty(); 
        }

      )
      
    }

  }

  mapValues(value: any): CustomerDto {
    debugger;
    const customerDto: CustomerDto = new CustomerDto();
    for (const key in customerDto) {
      if ((key in value) && value[key] ) {
        customerDto[key] = value[key];
      }
    }
    return customerDto;
  }

  
}

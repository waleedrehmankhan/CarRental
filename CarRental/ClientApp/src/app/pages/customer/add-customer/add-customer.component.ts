import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { CustomerDto } from '../../../classes/CustomerDto';
import { DataService } from '../../../data.service';
 


@Component({
  selector: 'add-customer',
  templateUrl: './add-customer.component.html',
  styleUrls: ['./add-customer.component.css']
})
export class AddCustomerComponent implements OnInit {
  errors: string[]
  customerForm: FormGroup;
  successfulSave: boolean;
  constructor(private fb: FormBuilder, private _dataService: DataService) {
  }

  customerDto = new CustomerDto();
  membershipurl: string = "membership/getMemberShip";

  ngOnInit(): void {


    this.customerForm = this.fb.group({
      CustomerCode: [""],
      FirstName: [""],
      LastName: [""],
      EmailAddress: [""],
      PhoneNumber: [""],
      LicenseNumber: [""],
      MembershipTypeId: [""],
    });
    this.errors = [];
  }

  submitForm(): void {
    if (this.customerForm.valid) {

      console.log(this.customerForm.value.MembershipTypeId);
      this.customerDto.customerCode = this.customerForm.value.CustomerCode;
      this.customerDto.firstName = this.customerForm.value.FirstName;
      this.customerDto.lastName = this.customerForm.value.LastName;
      this.customerDto.emailAddress = this.customerForm.value.EmailAddress;
      this.customerDto.phoneNumber = this.customerForm.value.PhoneNumber;
      this.customerDto.licenseNumber = this.customerForm.value.LicenseNumber;
      this.customerDto.membershipTypeId = this.customerForm.value.MembershipTypeId == null ? "0" : this.customerForm.value.MembershipTypeId;
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
           
            for (var fieldName in validationErrorDictionary) {
              if (validationErrorDictionary.hasOwnProperty(fieldName)) {
                this.errors.push(validationErrorDictionary[fieldName]);
                if (this.customerForm.controls[fieldName]) {
                  // integrate into angular's validation if we have field validation
                  this.customerForm.controls[fieldName].setErrors({ invalid: true });

               console.log(   this.customerForm.controls[fieldName].errors);
                }

                else {
                  // if we have cross field validation then show the validation error at the top of the screen
                  this.errors.push(validationErrorDictionary[fieldName]);
                }
              }
            }
          }
          else if (response.message.msgCode =="1")
          {
            this.successfulSave = true;
          }
          else if (response.data && response.data.message.msgCode == -3) {

            this.errors.push(response.data.message.msg);

          }
          else {
            this.errors.push("something went wrong!");



          }
        }

      )
      
    }

  }
}

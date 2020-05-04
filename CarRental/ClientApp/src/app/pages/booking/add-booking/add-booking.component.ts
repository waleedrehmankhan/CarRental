import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { DataService } from '../../../data.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NzMessageService } from 'ng-zorro-antd';
import { BookingDto } from '../../../classes/BookingDto';
 
 

@Component({
  selector: 'app-add-booking',
  templateUrl: './add-booking.component.html',
  styleUrls: ['./add-booking.component.css']
   
})
export class AddBookingComponent implements OnInit {
  errors: string[]
  booking: FormGroup
  customerForm:FormGroup
  successfulSave: boolean;
  show: boolean = false;
  checked: boolean = false;
  checkboxname: string = "Is New Customer";
 
  constructor(private fb: FormBuilder, private _dataService: DataService, private activatedRoute: ActivatedRoute, private router: Router, private message: NzMessageService) {
  }
  bookingDto = new BookingDto();
  branchurl: string = "branch/getBranchDetails";
  carurl: string = "car/getCarDetails";
  customerurl: string = "customers/getCustomerDetails"
  membershipurl: string = "membership/getMemberShip";

  ngOnInit() {

    const bookingId = this.activatedRoute.snapshot.params.Id;
    if (bookingId) {
      this.checkboxname="View Customer Details"
    }
    bookingId && this._dataService.postData("booking/getBookings", { "ID": bookingId }).subscribe
      (

        response => {
          const [booking] = response.data.Items;
          this.booking.patchValue(booking);

        }
      );
    this.customerForm = this.fb.group({

      CustomerCode: "",
      FirstName: "",
      LastName: "",
      EmailAddress: [""],
      PhoneNumber: [""],
      LicenseNumber: [""],
      MembershipTypeId: [0],
      BirthDate: [null]

    })
    this.booking = this.fb.group({
      Id: [bookingId],
      FromDate: [null],
      ReturnDate: [null],
      CustomerId: [""],
      CarId: [""],
      isActive: [true],
      FromBranchID: [""],
      ToBranchID: [""],
      Customer: this.customerForm,
      IsNewCustomer: [false]
    });
    console.log(this.booking);
  }

  submitForm = () => {
    if (this.booking.valid) {
      debugger;
      console.log(this.booking.value.MembershipTypeId);
      this.bookingDto = this.mapValues(this.booking.value);
      this.errors = [];
      console.log(this.bookingDto);
      this._dataService.postData("booking/createOrUpdateBooking", this.bookingDto).subscribe(

        response => {

          console.log(response);
          console.log();


          if (response.data && response.data.message.msgCode == -2) {

            let validationErrorDictionary = response.data.message.msg;
            debugger;
            console.log(validationErrorDictionary);

            setTimeout(() => {

              for (var fieldName in validationErrorDictionary) {
                this.booking.markAsDirty();
                this.booking.markAllAsTouched();
                if (validationErrorDictionary.hasOwnProperty(fieldName)) {
                  debugger;
                  this.errors.push(validationErrorDictionary[fieldName]);
                  if (this.booking.get(fieldName)) {
                    // integrate into angular's validation if we have field validation
                    // this.customerForm.controls[fieldName].setErrors({ invalid: true });

                    this.booking.get(fieldName).setErrors({ invalid: true, errors: validationErrorDictionary[fieldName] });
                    this.booking.get(fieldName).markAsTouched();
                    this.booking.get(fieldName).markAsDirty();



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
          else if (response.message.msgCode == "1") {
            this.successfulSave = true;

            this.message.success(response.message.msg, {
              nzDuration: 5000
            });
            this.router.navigateByUrl("booking/view")
          }
          else if (response.data && response.data.message.msgCode == -3) {
            debugger;
            console.log('hello');
            this.errors.push(response.data.message.msg);

          }
          else {
            this.errors.push("something went wrong!");



          }
          this.booking.markAsDirty();
        }

      )

    }

  }

  mapValues(value: any): BookingDto {
    debugger;
    const bookingDto: BookingDto = new BookingDto();
    for (const key in bookingDto) {
      if ((key in value) && value[key]) {
        bookingDto[key] = value[key];
      }
    }
    return bookingDto;
  }

  //toggle = ($event) => {
  //  $event.preventDefault();
  //  this.show = !this.show;
  //}


  
}

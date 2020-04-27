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
  bookingForm: FormGroup
  successfulSave: boolean;
 
  constructor(private fb: FormBuilder, private _dataService: DataService, private activatedRoute: ActivatedRoute, private router: Router, private message: NzMessageService) {
  }
  bookingDto = new BookingDto();
  branchurl: string = "branch/getBranchDetails";
  carurl: string = "car/getCarDetails";
  customerurl: string ="customers/getCustomerDetails"

  ngOnInit() {

    const bookingId = this.activatedRoute.snapshot.params.Id;

    bookingId && this._dataService.postData("booking/getBookings", { "ID": bookingId }).subscribe
      (

        response => {
          const [booking] = response.data.Items;
          this.bookingForm.patchValue(booking);

        }
      );

    this.bookingForm = this.fb.group({
      Id: [bookingId],
      FromDate: [null],
      ReturnDate: [null],
      CustomerId: [""],
      CarId: [""],
      isActive: [true],
      FromBranchID: [""],
      ToBranchID: [""],
      customerForm: this.fb.group({
        CustomerCode: "",
        FirstName: "",
        LastName: "",
        EmailAddress: [""],
        PhoneNumber: [""],
        LicenseNumber: [""],
        MembershipTypeId: [""],
        BirthDate: [null]

      })
    });
  }

  submitForm = () => {
    if (this.bookingForm.valid) {
      debugger;
      console.log(this.bookingForm.value.MembershipTypeId);
      this.bookingDto = this.mapValues(this.bookingForm.value);
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
                this.bookingForm.markAsDirty();
                this.bookingForm.markAllAsTouched();
                if (validationErrorDictionary.hasOwnProperty(fieldName)) {
                  this.errors.push(validationErrorDictionary[fieldName]);
                  if (this.bookingForm.controls[fieldName]) {
                    // integrate into angular's validation if we have field validation
                    // this.customerForm.controls[fieldName].setErrors({ invalid: true });

                    this.bookingForm.get(fieldName).setErrors({ invalid: true, errors: validationErrorDictionary[fieldName] });
                    this.bookingForm.get(fieldName).markAsTouched();
                    this.bookingForm.get(fieldName).markAsDirty();



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
          this.bookingForm.markAsDirty();
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

  
}

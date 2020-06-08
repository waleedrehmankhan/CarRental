import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { DataService } from '../../../data.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NzMessageService } from 'ng-zorro-antd';
import { ServiceHistoryDto } from '../../../classes/ServiceHistoryDto';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-add-history',
  templateUrl: './add-history.component.html',
  styleUrls: ['./add-history.component.css']
})
export class AddHistoryComponent implements OnInit {
  errors: string[]
  serviceForm: FormGroup;

  serviceDto = new ServiceHistoryDto();
  servicingstatus:string="true"
  constructor(

    private fb: FormBuilder,
    private _dataService: DataService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private message: NzMessageService

  ) { }
  carurl: string = "car/getCarDetails";
  url: string = "car/getCarServiceDetails";
  lstcolumns: string[] = ["DueDate:Date", "Description", "ServicingTypeName:ServicingType", "ServiceStatus:Status"]
  lstactions: string[] = ["delete:delete"];
  refresh = new Subject < boolean>();
  ngOnInit() {

    this.serviceForm = this.fb.group({
       
      Description: "",
      Status: "",
      DueDate: [null],
      CarId: [""],
      ServicingType: [""],
      Amoune:[""],
    });
    console.log(this.serviceForm);
    this.errors = [];
  }



  submitForm = () => {
    if (this.serviceForm.valid) {


      this.serviceDto = this.mapValues(this.serviceForm.value);
      this.errors = [];

      this._dataService.postData("car/createOrUpdateCarService", this.serviceDto).subscribe(

        response => {

          console.log(response);
          console.log();


          if (response.data && response.data.message.msgCode == -2) {

            let validationErrorDictionary = response.data.message.msg;
            debugger;
            console.log(validationErrorDictionary);

            setTimeout(() => {

              for (var fieldName in validationErrorDictionary) {
                this.serviceForm.markAsDirty();
                this.serviceForm.markAllAsTouched();
                if (validationErrorDictionary.hasOwnProperty(fieldName)) {
                  this.errors.push(validationErrorDictionary[fieldName]);
                  if (this.serviceForm.controls[fieldName]) {
                    // integrate into angular's validation if we have field validation
                    // this.customerForm.controls[fieldName].setErrors({ invalid: true });

                    this.serviceForm.get(fieldName).setErrors({ invalid: true, errors: validationErrorDictionary[fieldName] });
                    this.serviceForm.get(fieldName).markAsTouched();
                    this.serviceForm.get(fieldName).markAsDirty();



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
             

            this.message.success(response.message.msg, {
              nzDuration: 5000
            });

            this.refresh.next(true);
            this.serviceForm.reset();
          }
          else if (response.data && response.data.message.msgCode == -3) {
            debugger;
            console.log('hello');
            this.errors.push(response.data.message.msg);

          }
          else {
            this.errors.push("something went wrong!");



          }
          this.serviceForm.markAsDirty();
        }

      )

    }

  }

  mapValues(value: any): ServiceHistoryDto {
    debugger;
    const serviceDto: ServiceHistoryDto = new ServiceHistoryDto();
    for (const key in serviceDto) {
      if ((key in value) && value[key]) {
        serviceDto[key] = value[key];
      }
    }
    return serviceDto;
  }

  deleteClicked(data: ServiceHistoryDto) {
    this._dataService.postData("car/deleteServiceHistory", { "Id": data.Id }).subscribe(

      response => {

        this.refresh.next(true);
        this.message.success(response.message.msg, {
          nzDuration: 5000
        });
      }
    );
    this.refresh.next(true);
  }

}

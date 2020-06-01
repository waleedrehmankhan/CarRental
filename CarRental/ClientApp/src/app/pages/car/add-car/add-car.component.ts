import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, FormControl } from "@angular/forms";
import { CarDto } from "src/app/classes/CarDto";
import { DataService } from "src/app/data.service";
import { ActivatedRoute, Router } from "@angular/router";
import { NzMessageService } from "ng-zorro-antd";

@Component({
  selector: "app-add-car",
  templateUrl: "./add-car.component.html",
  styleUrls: ["./add-car.component.css"],
})
export class AddCarComponent implements OnInit {
  carForm: FormGroup;
  return: string = "";
  carDto = new CarDto();
  successfulSave: boolean;
  errors: string[];

  constructor(
    private fb: FormBuilder,
    private _dataService: DataService,
    private activatedRoute: ActivatedRoute,
    private message: NzMessageService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  carTypeUrl: string = "membership/getMemberShip";
  branchLocationUrl: string = "car/branchLocation";

  ngOnInit() {
    const Id = this.activatedRoute.snapshot.params.Id;

    this.carForm = this.fb.group({
      Id: Id || -1,
      RegistrationNumber: new FormControl(),
      Year: new FormControl(),
      Make: new FormControl(),
      Model: new FormControl(),
      Mileage: new FormControl(),
      isActive: new FormControl(),
      isAvailable: new FormControl(),
      PassengerCount: new FormControl(),
      CostPerHour: new FormControl(),
      CostPerDay: new FormControl(),
      LateFeePerHour: new FormControl(),
    });

    console.log(this.carForm);
    this.errors = [];
  }

  submitForm = () => {
    this.errors = [];
    if (this.carForm.valid) {
      console.log(this.carForm);

      //object
      this.carDto.Id = this.carForm.value.Id;
      this.carDto.RegistrationNumber = this.carForm.value.RegistrationNumber;
      this.carDto.Year = this.carForm.value.Year;
      this.carDto.Make = this.carForm.value.Make;
      this.carDto.Model = this.carForm.value.Model;
      this.carDto.Mileage = this.carForm.value.Mileage;
      this.carDto.isActive = this.carForm.value.isActive || true;
      this.carDto.isAvailable = this.carForm.value.isAvailable || true;
      this.carDto.CarClassification.PassengerCount = this.carForm.value.PassengerCount;
      this.carDto.CarClassification.CostPerHour = this.carForm.value.CostPerHour;
      this.carDto.CarClassification.CostPerDay = this.carForm.value.CostPerDay;
      this.carDto.CarClassification.LateFeePerHour = this.carForm.value.LateFeePerHour;

      console.log(this.carDto);

      this._dataService
        .postData("car/createOrUpdateCar", this.carDto)
        .subscribe(
          (res: any) => {
            if (res.data && res.data.message.msgCode == -2) {
              let validationErrorDictionary = res.data.message.msg;
              console.log(validationErrorDictionary);

              setTimeout(() => {
                for (var fieldName in validationErrorDictionary) {
                  this.carForm.markAsDirty();
                  this.carForm.markAllAsTouched();
                  if (validationErrorDictionary.hasOwnProperty(fieldName)) {
                    this.errors.push(validationErrorDictionary[fieldName]);
                    if (this.carForm.controls[fieldName]) {
                      // integrate into angular's validation if we have field validation
                      // this.customerForm.controls[fieldName].setErrors({ invalid: true });

                      this.carForm.get(fieldName).setErrors({
                        invalid: true,
                        errors: validationErrorDictionary[fieldName],
                      });
                      this.carForm.get(fieldName).markAsTouched();
                      this.carForm.get(fieldName).markAsDirty();

                      console.log(validationErrorDictionary[fieldName]);
                    } else {
                      // if we have cross field validation then show the validation error at the top of the screen
                      this.errors.push(validationErrorDictionary[fieldName]);
                    }
                  }
                }
              }, 100);
            } else if (res.message.msgCode == "1") {
              this.successfulSave = true;

              this.message.success(res.message.msg, {
                nzDuration: 5000,
              });
              this.router.navigateByUrl("car/view");
            } else if (res.data && res.data.message.msgCode == -3) {
              this.errors.push(res.data.message.msg);
            } else {
              this.errors.push("something went wrong!");
            }
            this.carForm.markAsDirty();
          },
          (err) => {
            this.errors.push("something went wrong!");
            console.log(err);
          }
        );
    }
  };
}

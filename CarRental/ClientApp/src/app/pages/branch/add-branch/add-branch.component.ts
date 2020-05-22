import { Component, OnInit } from "@angular/core";
import {
  FormBuilder,
  FormGroup,
  Validators,
  FormControl,
} from "@angular/forms";
import { DataService } from "../../../data.service";
import { ActivatedRoute, Router } from "@angular/router";
import { NzMessageService } from "ng-zorro-antd";
import { BranchDto } from "src/app/classes/BranchDto";

@Component({
  selector: "app-add-branch",
  templateUrl: "./add-branch.component.html",
  styleUrls: ["./add-branch.component.css"],
})
export class AddBranchComponent implements OnInit {
  branchForm: FormGroup;
  return: string = "";
  branchDto = new BranchDto();
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

  ngOnInit() {
    const Id = this.activatedRoute.snapshot.params.Id;

    Id &&
      this._dataService
        .postData("branch/getBranchDetails", { Id: Id })
        .subscribe((response) => {
          const [branch] = response.data.Items;
          this.branchForm.patchValue(branch);
        });

    this.branchForm = this.fb.group({
      Id: Id || -1,
      BranchName: new FormControl(),
      PhoneNumber: new FormControl(),
      Unit: new FormControl(),
      Street: new FormControl(),
      Suburb: new FormControl(),
      ZipCode: new FormControl(),
      City: new FormControl(),
      State: new FormControl(),
    });
    console.log(this.branchForm);
    this.errors = [];
  }

  submitForm = () => {
    this.errors = [];
    if (this.branchForm.valid) {
      debugger;
      console.log(this.branchForm);

      //object
      this.branchDto.Id = this.branchForm.value.Id;
      this.branchDto.BranchName = this.branchForm.value.BranchName;
      this.branchDto.PhoneNumber = this.branchForm.value.PhoneNumber;
      this.branchDto.Unit = this.branchForm.value.Unit;
      this.branchDto.Street = this.branchForm.value.Street;
      this.branchDto.Suburb = this.branchForm.value.Suburb;
      this.branchDto.ZipCode = this.branchForm.value.ZipCode;
      this.branchDto.City = this.branchForm.value.City;
      this.branchDto.State = this.branchForm.value.State;

      console.log(this.branchDto);

      this._dataService
        .postData("branch/createOrUpdateBranch", this.branchDto)
        .subscribe(
          (res: any) => {
            if (res.data && res.data.message.msgCode == -2) {
              let validationErrorDictionary = res.data.message.msg;
              console.log(validationErrorDictionary);

              setTimeout(() => {
                for (var fieldName in validationErrorDictionary) {
                  this.branchForm.markAsDirty();
                  this.branchForm.markAllAsTouched();
                  if (validationErrorDictionary.hasOwnProperty(fieldName)) {
                    this.errors.push(validationErrorDictionary[fieldName]);
                    if (this.branchForm.controls[fieldName]) {
                      // integrate into angular's validation if we have field validation
                      // this.customerForm.controls[fieldName].setErrors({ invalid: true });

                      this.branchForm.get(fieldName).setErrors({
                        invalid: true,
                        errors: validationErrorDictionary[fieldName],
                      });
                      this.branchForm.get(fieldName).markAsTouched();
                      this.branchForm.get(fieldName).markAsDirty();

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
              this.router.navigateByUrl("branch/view");
            } else if (res.data && res.data.message.msgCode == -3) {
              this.errors.push(res.data.message.msg);
            } else {
              this.errors.push("something went wrong!");
            }
            this.branchForm.markAsDirty();
          },
          (err) => {
            this.errors.push("something went wrong!");
            console.log(err);
          }
        );
    }
  };
}

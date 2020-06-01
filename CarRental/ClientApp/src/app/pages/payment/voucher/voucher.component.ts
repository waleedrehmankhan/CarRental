import { Component, OnInit, Input } from '@angular/core';
import { InvoiceDetailDto } from '../../../classes/InvoiceDetailDto';
import { DataService } from '../../../data.service';
import { PrintingService } from '../../../printing.service';
import { ExtraDto } from '../../../classes/ExtraDto';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { PaymentDto } from '../../../classes/PaymentDto';
import { NzMessageService } from 'ng-zorro-antd';
interface keyable {
  [key: string]: any;
}

@Component({
  selector: 'app-voucher',
  templateUrl: './voucher.component.html',
  styleUrls: ['./voucher.component.css']
})
export class VoucherComponent implements OnInit {
  errors: string[]
  paymentForm: FormGroup
  @Input() data:any

  invoiceDetails: InvoiceDetailDto;
  paymentDto = new PaymentDto();
  amountreceived: number = 0;
  amountreturn: number = 0;
  bookingextralist: ExtraDto[];
  url: string = "invoice/getInvoiceItemDetails"
  constructor(private _dataService: DataService, private _printingService: PrintingService, private activatedRoute: ActivatedRoute, private fb: FormBuilder, private message: NzMessageService) { }

  ngOnInit() {
    this.paymentForm = new FormGroup(
      {

        TotalAmount: new FormControl(),
        AmountReceived: new FormControl(),
        AmountReturn: new FormControl(),
        Remarks: new FormControl(),
        PaymentDate:new FormControl(),
        PaymentType: new FormControl(),
        InvoiceId: new FormControl(),
      
      });


    const invoiceId = this.activatedRoute.snapshot.params.Id;
    this.getInvoiceDetails(invoiceId);
    
  }

  getInvoiceDetails(id) {
    this._dataService.postData(this.url, { "Id":id}).subscribe
      (

        response => {
          debugger;
          var itemsarray = new Array();
          for (var v in response.data.Items) {
            debugger;
            itemsarray.push(this.convertIntoOneLevelJson(response.data.Items[v]));
          }
         
          this.invoiceDetails = response.data.Items[0];
          if (!this.invoiceDetails.Payment) { this.invoiceDetails.Payment = new PaymentDto() }
          console.log(this.invoiceDetails);
          this.bookingextralist = this.invoiceDetails.BookingExtraList;
        }
      );

  }

  getValue = (str: string) => {
    const match = str.match(/\{[^\{\}]*\}/gm);
    if (match && match.length > 0) {
      return str.replace(/\{[^\{\}]*\}/gm, x => {
        const key = x.substring(1, x.length - 1);
        if (key in this.data) {
          const retData = this.data[key];
          if (retData && retData.constructor === (0).constructor) {
            return (retData as Number).toFixed(4);
          }
          return this.data[key];
        }
        return '';
      });
    }
    if (str in this.data) {
      return this.data[str];
    }
    return "";
  }
  toUpper(str: string): string {
    return str.toUpperCase();
  }

  convertIntoOneLevelJson = (activity: any, key = ""): any => {
    let response: keyable = {};
    if (
      activity &&
      (activity["constructor"] === "".constructor ||
        activity["constructor"] === (0).constructor)
    ) {
      response[key] = activity;
    } else if (activity === null) {
      response[key] = null;
    } else if (activity && activity["constructor"] === {}.constructor) {
      for (const k in activity) {
        if (k in activity) {
          if (key) {
            response = {
              ...response,
              ...this.convertIntoOneLevelJson(activity[k], `${key}.${k}`)
            };
          } else {
            response = {
              ...response,
              ...this.convertIntoOneLevelJson(activity[k], `${k}`)
            };
          }
        }
      }
    } else if (activity && activity["constructor"] === [].constructor) {
      for (let i = 0; i < activity.length; i++) {
        response = {
          ...response,
          ...this.convertIntoOneLevelJson(activity[i], `${key}[${i}]`)
        };
      }
    } else {
      response[key] = activity;
    }
    return response;
  };


  print() {
    const printClass = "printArea";
    const printingDiv = document.getElementsByClassName(printClass)[0] as HTMLDivElement;
    const htmlContent = printingDiv.innerHTML;
    this._printingService.printContents(htmlContent, 'Transaction Voucher', false, `
          .invoice-box {
  max-width: 800px;
  margin: auto;
  padding: 30px;
  border: 1px solid #eee;
  box-shadow: 0 0 10px rgba(0, 0, 0, .15);
  font-size: 16px;
  line-height: 24px;
  font-family: 'Helvetica Neue', 'Helvetica', Helvetica, Arial, sans-serif;
  color: #555;
}

  .invoice-box table {
    width: 100%;
    line-height: inherit;
    text-align: left;
  }

    .invoice-box table td {
      padding: 5px;
      vertical-align: top;
    }

    .invoice-box table tr td:nth-child(2) {
      text-align: right;
    }

    .invoice-box table tr.top table td {
      padding-bottom: 20px;
    }

      .invoice-box table tr.top table td.title {
        font-size: 45px;
        line-height: 45px;
        color: #333;
      }

    .invoice-box table tr.information table td {
      padding-bottom: 40px;
    }

    .invoice-box table tr.heading td {
      background: #eee;
      border-bottom: 1px solid #ddd;
      font-weight: bold;
    }

    .invoice-box table tr.details td {
      padding-bottom: 20px;
    }

    .invoice-box table tr.item td {
      border-bottom: 1px solid #eee;
    }

    .invoice-box table tr.item.last td {
      border-bottom: none;
    }

    .invoice-box table tr.total td:nth-child(2) {
      border-top: 2px solid #eee;
      font-weight: bold;
    }

@media only screen and (max-width: 600px) {
  .invoice-box table tr.top table td {
    width: 100%;
    display: block;
    text-align: center;
  }

  .invoice-box table tr.information table td {
    width: 100%;
    display: block;
    text-align: center;
  }
}

/** RTL **/
.rtl {
  direction: rtl;
  font-family: Tahoma, 'Helvetica Neue', 'Helvetica', Helvetica, Arial, sans-serif;
}

  .rtl table {
    text-align: right;
  }

    .rtl table tr td:nth-child(2) {
      text-align: left;
    }

        
      `);
  }
  submitForm = () => {
    if (this.paymentForm.valid) {

      this.paymentDto = this.mapValues(this.paymentForm.value);
      this.errors = [];
      console.log(this.paymentDto);
      this._dataService.postData("invoice/PayInvoice", this.paymentDto).subscribe(

        response => {

          console.log(response);
          console.log();


          if (response.data && response.data.message.msgCode == -2) {

            let validationErrorDictionary = response.data.message.msg;
            debugger;
            console.log(validationErrorDictionary);

            setTimeout(() => {

              for (var fieldName in validationErrorDictionary) {
                this.paymentForm.markAsDirty();
                this.paymentForm.markAllAsTouched();
                if (validationErrorDictionary.hasOwnProperty(fieldName)) {
                  this.errors.push(validationErrorDictionary[fieldName]);
                  if (this.paymentForm.controls[fieldName]) {
                    // integrate into angular's validation if we have field validation
                    // this.customerForm.controls[fieldName].setErrors({ invalid: true });

                    this.paymentForm.get(fieldName).setErrors({ invalid: true, errors: validationErrorDictionary[fieldName] });
                    this.paymentForm.get(fieldName).markAsTouched();
                    this.paymentForm.get(fieldName).markAsDirty();



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
       

            this.invoiceDetails.Invoice.status = true;
            setTimeout(function () {
              let element: HTMLElement = document.getElementById('printReceipt') as HTMLElement
              element.click(); },5000)
           
          }
          else if (response.data && response.data.message.msgCode == -3) {
            debugger;
            console.log('hello');
            this.errors.push(response.data.message.msg);

          }
          else {
            this.errors.push("something went wrong!");



          }
          this.paymentForm.markAsDirty();
        }

      )

    }
  }

  mapValues(value: any): PaymentDto {
    debugger;
    const paymentDto: PaymentDto = new PaymentDto();
    for (const key in paymentDto) {
      if ((key in value) && value[key]) {
        paymentDto[key] = value[key];
      }
    }
    return paymentDto;
  }

  onKeydown(event) {
    debugger;
     
    this.amountreturn = this.amountreceived - this.invoiceDetails.Invoice.Amount;
  }
   
}

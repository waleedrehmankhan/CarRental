import { Component, OnInit, forwardRef, Output, EventEmitter } from '@angular/core';
import { UploadFile, NzMessageService } from 'ng-zorro-antd';
import { Observer, Observable } from 'rxjs';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { HttpEventType, HttpClient } from '@angular/common/http';

@Component({
  selector: 'crfile',
  templateUrl: './crfile.component.html',
  styleUrls: ['./crfile.component.css'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => CrfileComponent),
      multi: true
    }
  ]
})
export class CrfileComponent implements OnInit, ControlValueAccessor{
  public progress: number;
  public message: string;
  @Output() public onUploadFinished = new EventEmitter();
  loading = false;
  avatarUrl?: string;
  selectedValue = null;
  changeFn: any;
  touchChangeFn: any;
  isDisabled: boolean;
  constructor(private msg: NzMessageService, private http: HttpClient) { }

  ngOnInit() {
  }





  beforeUpload = (file: File) => {
    console.log("upload file", file);
    this.loading = true;
    const formData = new FormData();
    const reader = new FileReader();

    formData.append('file', file, file.name);
  
    this.http.post('/api/image/uploadCarImage', formData, { reportProgress: true })
      .subscribe((event: {url: string}) => {
        console.log(event);
        this.changeFn(event.url);
        this.touchChangeFn(event.url);
      });

    this.getBase64(file, (img: string) => {
      this.loading = false;
      this.avatarUrl = img;
    });
    return false;
  };

  private getBase64(img: File, callback: (img: string) => void): void {
    const reader = new FileReader();
    reader.addEventListener('load', () => callback(reader.result!.toString()));
    reader.readAsDataURL(img);
  }

  handleChange(info: { file: UploadFile }): void {
    console.log(info.file)
    
    switch (info.file.status) {
      case 'uploading':
        this.loading = true;
        let fileToUpload = <UploadFile>info.file;
        const formData = new FormData();
        formData.append('file', info.file!.originFileObj!, fileToUpload.name);

        this.http.post('/api/image/uploadCarImage', formData, { reportProgress: true, observe: 'events' })
          .subscribe(event => {
            if (event.type === HttpEventType.UploadProgress)
              this.progress = Math.round(100 * event.loaded / event.total);
            else if (event.type === HttpEventType.Response) {
              this.message = 'Upload success.';
              this.onUploadFinished.emit(event.body);
            }
          });
        break;
      case 'done':
        // Get this url from response in real world.
        this.getBase64(info.file!.originFileObj!, (img: string) => {
          this.loading = false;
          this.avatarUrl = img;
        });
        break;
      case 'error':
        this.msg.error('Network error');
        this.loading = false;
        break;
    }
  }

  handleUpload(file: UploadFile): string {
    console.log(file)
    return "";
    
  }

  writeValue(obj: any): void {
    this.selectedValue = obj;
    console.log(obj);
  }

  registerOnChange(fn: any): void {
    this.changeFn = fn;
    console.log('changed')
  }

  registerOnTouched(fn: any): void {
    this.touchChangeFn = fn;
  }

  setDisabledState?(isDisabled: boolean): void {
    this.isDisabled = isDisabled;
  }
}

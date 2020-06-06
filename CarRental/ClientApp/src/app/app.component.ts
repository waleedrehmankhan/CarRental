import { Component, OnInit, AfterViewInit, ChangeDetectorRef } from '@angular/core';
import { TokenInterceptor } from './interceptor/token.interceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  providers: [
  ]
})
export class AppComponent {

  constructor() {
  }

  title = 'app';
 

  
}

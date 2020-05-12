import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { NgZorroAntdModule, NZ_I18N, en_US, NzInputModule } from 'ng-zorro-antd';
import { AppRoutingModule } from './app-routing.module';
import { LayoutModule } from './shared/layout/layout.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DataService } from './data.service';
import { AccountModule } from './account/account.module';
 

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    AppRoutingModule,
    LayoutModule,
    AccountModule,
    NzInputModule,
    BrowserAnimationsModule
    //RouterModule.forRoot([
    //  { path: '', component: HomeComponent, pathMatch: 'full' },
    //  { path: 'counter', component: CounterComponent },
    //  { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
    //])
  ],
  providers: [DataService,
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }, { provide: NZ_I18N, useValue: en_US },
    { provide: "API_BASE_URL", useValue:"/api/" }
  ],
  bootstrap: [AppComponent]
   
})
export class AppModule { }

import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
 
import { Observable, Subject } from 'rxjs';
import { finalize, tap } from 'rxjs/operators';
import { AuthService } from '../auth/auth.service';
import { Router, RouterStateSnapshot, ActivatedRoute } from '@angular/router';
 
 
@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  constructor(public auth: AuthService, private router: Router, private route: ActivatedRoute) { }

  loading = new Subject<boolean>();

  count = 0;

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    this.count++;
    if (!this.auth.isAuthenticated()) {
      
        this.router.navigate(['login']);
 
    }
    request = request.clone({
      setHeaders: {
        Authorization: `Bearer ${this.auth.getToken()}`
      }
    });
    this.loading.next(true);
    return next.handle(request).pipe(tap(
      event => console.log(event),
      error => console.log(error)
    ),finalize(() => {
      this.count--;
      if (this.count == 0) {
        this.loading.next(false);
      }
    }));
  }


}

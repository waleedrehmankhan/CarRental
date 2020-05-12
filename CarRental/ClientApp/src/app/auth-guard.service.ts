import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService {

  constructor(public auth: AuthService, public router: Router) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    debugger;
    if (sessionStorage.getItem("current_user")) {
       
      return true;
    }
    if (!this.auth.isAuthenticated()) {
      this.router.navigate(['login'],{
        queryParams: {
          return: state.url
        }
      });
      return false;
    }
  
      
   
  }
}

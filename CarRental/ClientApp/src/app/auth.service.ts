import { Injectable } from '@angular/core';
//import { JwtHelperService } from '@auth0/angular-jwt';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
   ) { }

  public jwtHelper: JwtHelperService = new JwtHelperService();
  // ...
  public isAuthenticated(): boolean {
    const token = sessionStorage.getItem('current_user')&& JSON.parse(sessionStorage.getItem('current_user')).CurrentToken;
    // Check whether the token is expired and return
    // true or false
    return !this.jwtHelper.isTokenExpired(token);
  }
}

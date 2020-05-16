import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { SidebarmenuService } from '../shared/services/sidebarmenu.service';
 

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService {

  constructor(public auth: AuthService, public router: Router, private _menuService: SidebarmenuService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    debugger;
    let currentuser = sessionStorage.getItem("current_user") && JSON.parse(sessionStorage.getItem("current_user"))
    if (currentuser) {
      //filter
      
      let config = this._menuService.routerConfig;
      if (currentuser.UserRole == "Staff") {
        config = this._menuService.staffRouterConfig;
      }

      const canGo = this.canGoToMenu(state, config);
      console.log(canGo);
      if (!canGo) {
        debugger;
        this.router.navigateByUrl('error/error');
      }
      return canGo;
      //return true;
    }
    if (!this.auth.isAuthenticated()) {
      this.router.navigate(['login'], {
        queryParams: {
          return: state.url
        }
      });
      return false;
    }



  }
  canGoToMenu(state: RouterStateSnapshot, config: any[]): boolean {
    const routerLink = state.url;
    let flag = false;
    for (const c of config) {
      if (c.children) {
        flag = this.canGoToMenu(state, c.children);
      }
      if (flag) return true;
              console.log(c, c.routerLink === routerLink, routerLink);
      if (c.routerLink === routerLink) {
        return true;
      }
      console.log("muni");
    }

    return flag;
  }
}

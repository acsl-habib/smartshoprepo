import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from "@angular/router";
import { AuthenticationService } from "../services/authentication/authentication.service";
import { UserService } from "../services/authentication/user.service";
import { NotifyService } from "../services/common/notify.service";
@Injectable()
export class AuthGuard implements CanActivate{
  constructor(
    private router: Router,
    private userService: UserService,

    private notifyService: NotifyService
  ) {


   }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    //if not logged in reject i.e., return false

    this.userService.load();
    
    if (this.userService.isLogged) {
      //console.log(route.data.AllowedRoles);
      if (new Date() >= <Date>this.userService.expiration) {
        this.notifyService.fail("Session expired. Login again", "DISMISS");
        this.userService.logout();
        this.router.navigate(['/login']);
        return false;
      }
      if (route.data.AllowedRoles && !this.userService.roleMatch(route.data.AllowedRoles)) {
        this.notifyService.fail("Forbidden: you are not allwed to access the resource", "DISMISS");
        return false;
      }

      return true;
    }
    else {
      this.notifyService.fail("You must login to access the resource.", "DISMISS")
      this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
      return false;
    }


  }
}

import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { AppConstants } from '../../../config/app-constants';
import { UserService } from 'src/app/services/authentication/user.service';
import {AuthenticationService} from "src/app/services/authentication/authentication.service";
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent {
  appName = AppConstants.appName;
  appitems = AppConstants.navItems;
  config = {
    paddingAtStart: true,
    interfaceWithRoute: true,

    fontColor: `rgb(8, 54, 71)`,


    highlightOnSelect: true,
    collapseOnSelect: true,
    useDividers: true,
    rtlLayout: false
  };
  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );
  get isLogged(){
    return this.userService.isLogged;
  }
  get userName():string{
    return this.userService.userName;
  }
  logout(){
    this.loginService.logout();
    this.router.navigateByUrl("/home");
  }
  constructor(
    private breakpointObserver: BreakpointObserver,
    private userService: UserService,
    private loginService:AuthenticationService,
    private router:Router
    ) {

    }

}

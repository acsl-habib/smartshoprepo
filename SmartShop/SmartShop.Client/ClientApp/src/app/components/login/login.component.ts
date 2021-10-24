import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginModel } from 'src/app/models/authentication/login-model';
import { AuthenticationService } from 'src/app/services/authentication/authentication.service';
import { NotifyService } from 'src/app/services/common/notify.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
   data!:LoginModel;
   returnUrl:string="/home";
  constructor(
    private loginService:AuthenticationService,
    private notifyService:NotifyService,
    private router:Router,
    private activatedRoute:ActivatedRoute
  ) { }
 login(f:NgForm){
   console.log(this.data);
   this.loginService.login(this.data)
   .subscribe(
     r=>{
        this.router.navigateByUrl(this.returnUrl);
     },
     err=>{
       this.notifyService.fail("Login failed, check username & password", "DISMISS");
     }
   )
 }
  ngOnInit(): void {
    this.activatedRoute.queryParams.subscribe(q=>{
      this.returnUrl = q['returnUrl'] ?? "/home";
      console.log(this.returnUrl);
    })
    this.data = new LoginModel();
  }

}

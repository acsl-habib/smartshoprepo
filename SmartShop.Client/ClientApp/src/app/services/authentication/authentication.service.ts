import { HttpClient, HttpHeaders } from '@angular/common/http';
import { EventEmitter, Injectable, Output } from '@angular/core';
import { BehaviorSubject, empty, Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppConstants } from 'src/app/config/app-constants';
import { LoginModel } from 'src/app/models/authentication/login-model';
import { User } from 'src/app/models/authentication/user';



@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private currentUserSubject: BehaviorSubject<User>;
  private currentUser: Observable<User>;
  @Output() loginEvent: EventEmitter<string> = new EventEmitter<string>();
  constructor(
    private http: HttpClient
  ) {
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(sessionStorage.getItem("user-data") as string));
    this.currentUser = this.currentUserSubject.asObservable();
  }
  get currentUserValue() {
    return this.currentUserSubject.value;
  }
  login(data: LoginModel) {
    let noTokenHeader = { headers: new HttpHeaders({ 'notoken': 'no token' }) }
    return this.http.post<any>(`${AppConstants.apiUrl}/api/Account/Login`, data, noTokenHeader)
      .pipe(map(data => {
        let user = this.save(data);
        this.currentUserSubject.next(user);
        this.loginEvent.emit('login');
      }),
        catchError((err, caught) => {

          this.currentUserSubject.next(new User());
          return throwError(err);
        }));
  }
  refreshToken() {
    
   /* let noTokenHeader = { headers: new HttpHeaders({ 'notoken': 'no token' }) }*/
    return this.http.post<any>(`${AppConstants.apiUrl}/api/Account/RefreshToken/${this.currentUserValue.refreshToken}`, null)
      //.subscribe(x => {
      //  let user = this.save(x);
      //  this.currentUserSubject.next(user);
      //  this.loginEvent.emit('refresh');
        
      //});
      .pipe(map(data => {
        let user = this.save(data);
        this.currentUserSubject.next(user);
        this.loginEvent.emit('refresh');
      }),
        catchError((err, caught) => {

          this.currentUserSubject.next(new User());
          return throwError(err);
        }));
  }
  logout() {
    sessionStorage.removeItem("user-data");
    this.currentUserSubject.next(new User());
    this.loginEvent.emit('logout');
  }
  save(data: any): User {
    const userdata = new User();
    //console.log(new Date() >= new Date(data.expiration));
    userdata.accessToken = data.token;
    userdata.tokenExipres = new Date(data.expiration);
    userdata.refreshToken = data.refreshToken;
    const payload = JSON.parse(window.atob(data.token.split('.')[1]));
    userdata.userName = payload.username;
    userdata.role = payload.role.split(",");
    
    sessionStorage.setItem("user-data", JSON.stringify(userdata));
    return userdata;
  }
  getEmitter() {
    return this.loginEvent;
  }
}

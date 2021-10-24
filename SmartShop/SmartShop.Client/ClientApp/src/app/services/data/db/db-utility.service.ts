import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConstants } from 'src/app/config/app-constants';

@Injectable({
  providedIn: 'root'
})
export class DbUtilityService {

  constructor(
    private http:HttpClient
  ) { }
  getDbStatus():Observable<boolean>{
    return this.http.get<boolean>(`${AppConstants.apiUrl}/api/DataUtility/Status`);
  }
  initDb():Observable<any>{
    return this.http.post<any>(`${AppConstants.apiUrl}/api/DataUtility/Migrate`, null)
  }
}

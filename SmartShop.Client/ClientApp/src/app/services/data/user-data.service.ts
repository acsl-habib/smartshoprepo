import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConstants } from '../../config/app-constants';
import { UserDataModel } from '../../models/data/user-data-model';

@Injectable({
  providedIn: 'root'
})
export class UserDataService {

  constructor(
    private http: HttpClient
  ) { }
  get(): Observable<UserDataModel[]> {
    return this.http.get<UserDataModel[]>(`${AppConstants.apiUrl}/api/UserData`);
  }
}

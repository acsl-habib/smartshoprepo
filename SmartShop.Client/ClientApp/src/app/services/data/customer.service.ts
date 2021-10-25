import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConstants } from '../../config/app-constants';
import { CustomerModel } from './customer-model';


@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(
    private http:HttpClient
  ) { }
  getCustomer():Observable<CustomerModel[]>{
    return this.http.get<CustomerModel[]>(`${AppConstants.apiUrl}/api/Customers`);
  }
}

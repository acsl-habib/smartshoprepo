import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConstants } from '../../config/app-constants';
import { ShippingModel } from '../../models/data/shipping-model';

@Injectable({
  providedIn: 'root'
})
export class ShippingService {

  constructor(private http: HttpClient) { }
  get(): Observable<ShippingModel[]> {
    return this.http.get<ShippingModel[]>(`${AppConstants.apiUrl}/api/Shippings`);
  }
  getById(id: number): Observable<ShippingModel> {
    return this.http.get<ShippingModel>(`${AppConstants.apiUrl}/api/Shippings/${id}`);
  }
  create(shipping: ShippingModel): Observable<ShippingModel> {
    return this.http.post<ShippingModel>(`${AppConstants.apiUrl}/api/Shippings`, shipping);
  }
  update(shipping: ShippingModel): Observable<ShippingModel> {
    return this.http.put<any>(`${AppConstants.apiUrl}/api/Shippings/${shipping.shippingId}`, shipping);
  }
  delete(id: number): Observable<ShippingModel> {
    return this.http.delete<ShippingModel>(`${AppConstants.apiUrl}/api/Shippings/${id}`);
  }
}

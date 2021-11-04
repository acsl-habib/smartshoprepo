import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConstants } from '../../config/app-constants';
import { PaymentModel } from '../../models/data/payment-model';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  constructor(private http: HttpClient) { }
  get(): Observable<PaymentModel[]> {
    return this.http.get<PaymentModel[]>(`${AppConstants.apiUrl}/api/Payments`);
  }
  getById(id: number): Observable<PaymentModel> {
    return this.http.get<PaymentModel>(`${AppConstants.apiUrl}/api/Payments/${id}`);
  }
  create(payment: PaymentModel): Observable<PaymentModel> {
    return this.http.post<PaymentModel>(`${AppConstants.apiUrl}/api/Payments`, payment);
  }
  update(payment: PaymentModel): Observable<PaymentModel> {
    return this.http.put<any>(`${AppConstants.apiUrl}/api/Payments/${payment.paymentId}`, payment);
  }
  delete(id: number): Observable<PaymentModel> {
    return this.http.delete<PaymentModel>(`${AppConstants.apiUrl}/api/Payments/${id}`);
  }
}

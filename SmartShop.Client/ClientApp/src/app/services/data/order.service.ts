import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConstants } from '../../config/app-constants';
import { OrderStatus } from '../../models/constants/enum-data';
import { ConfirmBoolDataModel } from '../../models/data/input/confirm-bool-data-model';
import { OrderStatusDataModel } from '../../models/data/input/order-status-data-model';
import { OrderModel } from '../../models/data/order-model';
import { OrderSummaryModel } from '../../models/data/viewmodels/order-summary-model';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(
    private http: HttpClient
  ) { }
  getPendingCount(): Observable<number> {
    return this.http.get<number>(`${AppConstants.apiUrl}/api/Orders/Pending`);
  }
  get(): Observable<OrderModel[]> {
    return this.http.get<OrderModel[]>(`${AppConstants.apiUrl}/api/Orders`);
  }
  getPending(): Observable<OrderModel[]> {
    return this.http.get<OrderModel[]>(`${AppConstants.apiUrl}/api/Orders/PendingOrders`);
  }
  getUnfirmed(): Observable<OrderModel[]> {
    return this.http.get<OrderModel[]>(`${AppConstants.apiUrl}/api/Orders/Unfirmed`);
  }
  getOfStatus(data: OrderStatus): Observable<OrderModel[]> {
    //OfStatus
    return this.http.get<OrderModel[]>(`${AppConstants.apiUrl}/api/Orders/OfStatus/${data}`);
  }
  getOrderSummary(id: number): Observable<OrderSummaryModel> {
    return this.http.get<OrderSummaryModel>(`${AppConstants.apiUrl}/api/Orders/${id}/Summary`);
  }
  changeOrderConfirmation(id: number, data: ConfirmBoolDataModel): Observable<boolean> {
    return this.http.post<boolean>(`${AppConstants.apiUrl}/api/Orders/${id}/Confirm`, data);
  }
  changeOrderStatus(id: number, data: OrderStatusDataModel): Observable<boolean> {
    return this.http.post<boolean>(`${AppConstants.apiUrl}/api/Orders/${id}/OrderStatus`, data);
  }
}


import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConstants } from 'src/app/config/app-constants';
import { BrandModel } from 'src/app/models/data/brand-model';
import { ProductModel } from '../../models/data/product-model';

@Injectable({
  providedIn: 'root'
})
export class BrandService {

  constructor(
    private http:HttpClient
  ) { }
  get():Observable<BrandModel[]>{
    return this.http.get<BrandModel[]>(`${AppConstants.apiUrl}/api/Brands`);
  }
  getById(id: number): Observable<BrandModel> {
    return this.http.get<BrandModel>(`${AppConstants.apiUrl}/api/Brands/${id}`);
  }
  create(data: BrandModel): Observable<BrandModel> {
    return this.http.post<BrandModel>(`${AppConstants.apiUrl}/api/Brands`, data);
  }
  update(data: BrandModel): Observable<any> {
    return this.http.put<any>(`${AppConstants.apiUrl}/api/Brands/${data.brandId}`, data);
  }
  delete(id: number): Observable<BrandModel> {
    return this.http.delete<BrandModel>(`${AppConstants.apiUrl}/api/Brands/${id}`);
  }
  getProducts(id: number): Observable<ProductModel[]> {
    return this.http.get<ProductModel[]>(`${AppConstants.apiUrl}/api/Brands/${id}/Products`);
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConstants } from '../../config/app-constants';
import { ProductAndPriceInputModel } from '../../models/data/input/product-and-price-input-model';
import { ProductConfigurationInputModel } from '../../models/data/input/product-configuration-input-model';
import { ProductModel } from '../../models/data/product-model';
import { ImagePathResponse } from '../../models/data/viewmodels/image-path-response';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(
    private http: HttpClient
  ) { }
  get(): Observable<ProductModel[]> {
    return this.http.get<ProductModel[]>(`${AppConstants.apiUrl}/api/Products`);
  }
  getById(id: number): Observable<ProductModel> {
    return this.http.get<ProductModel>(`${AppConstants.apiUrl}/api/Products/${id}`);
  }
  getInclude(): Observable<ProductModel[]> {
    return this.http.get<ProductModel[]>(`${AppConstants.apiUrl}/api/Products/Include`);
  }
  getIncludeById(id: number): Observable<ProductModel> {
    return this.http.get<ProductModel>(`${AppConstants.apiUrl}/api/Products/${id}/Include`);
  }
  getProptertyNames(): Observable<string[]> {
    return this.http.get<string[]>(`${AppConstants.apiUrl}/api/Products/PropNames`);
  }
  getSizes() { }
  getColors() { }
  getImages() { }
  save(data: ProductModel): Observable<ProductModel> {
    return this.http.post<ProductModel>(`${AppConstants.apiUrl}/api/Products`, data);
  }
  saveWithPrice(data: ProductAndPriceInputModel): Observable<ProductModel> {
    return this.http.post<ProductModel>(`${AppConstants.apiUrl}/api/Products/WithPrice`, data);
  }
  saveSpecs(data: ProductConfigurationInputModel): Observable<any> {
    return this.http.post<ProductModel>(`${AppConstants.apiUrl}/api/Products/Specs`, data);
  }
  update(data: ProductModel): Observable<any> {
    return this.http.put<any>(`${AppConstants.apiUrl}/api/Products/${data.productId}`, data);
  }
  delete(id: Number): Observable<ProductModel> {
    return this.http.delete<ProductModel>(`${AppConstants.apiUrl}/api/Products/${id}`);
  }
  uploadImage(id: number, f: File): Observable<ImagePathResponse> {
    const formData = new FormData();

    formData.append('file', f);
    //console.log(f);
    return this.http.post<ImagePathResponse>(`${AppConstants.apiUrl}/api/Images/${id}`, formData);
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConstants } from '../../config/app-constants';
import { ProductEditModel } from '../../models/data/edit/product-edit-model';
import { ProductAndPriceInputModel } from '../../models/data/input/product-and-price-input-model';
import { ProductConfigurationInputModel } from '../../models/data/input/product-configuration-input-model';
import { ProductImageModel } from '../../models/data/product-image-model';
import { ProductModel } from '../../models/data/product-model';
import { ProductPriceModel } from '../../models/data/product-price-model';
import { ProductSpecModel } from '../../models/data/product-spec-model';
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
  getByIdForEdit(id: number): Observable<ProductEditModel> {
    return this.http.get<ProductEditModel>(`${AppConstants.apiUrl}/api/Products/${id}/ForEdit`);
  }
  getInclude(): Observable<ProductModel[]> {
    return this.http.get<ProductModel[]>(`${AppConstants.apiUrl}/api/Products/Include`);
  }
  getIncludeById(id: number): Observable<ProductModel> {
    return this.http.get<ProductModel>(`${AppConstants.apiUrl}/api/Products/${id}/Include`);
  }
  getByBrandInclude(id: number): Observable<ProductModel[]> {
    return this.http.get<ProductModel[]>(`${AppConstants.apiUrl}/api/Products/Brand/${id}/Include`);
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
  saveProductPrice(data: ProductPriceModel): Observable<ProductPriceModel> {
    return this.http.post<ProductPriceModel>(`${AppConstants.apiUrl}/api/ProductPrices`, data);
  }
  saveProductSpec(data: ProductSpecModel): Observable<ProductSpecModel> {
    return this.http.post<ProductSpecModel>(`${AppConstants.apiUrl}/api/ProductSpecs`, data);
  }
  update(data: ProductModel): Observable<any> {
    return this.http.put<any>(`${AppConstants.apiUrl}/api/Products/${data.productId}`, data);
  }
  updateProductPrice(data: ProductPriceModel):Observable<any> {
    return this.http.put<any>(`${AppConstants.apiUrl}/api/ProductPrices/${data.productPriceId}`, data);
  }
  updateProductSpec(data: ProductSpecModel): Observable<any> {
    return this.http.put<any>(`${AppConstants.apiUrl}/api/ProductSpecs/${data.productSpecId}`, data);
  }
  delete(id: Number): Observable<ProductModel> {
    return this.http.delete<ProductModel>(`${AppConstants.apiUrl}/api/Products/${id}`);
  }
  deleteProductPrice(id: number): Observable<ProductPriceModel> {
    return this.http.delete<ProductModel>(`${AppConstants.apiUrl}/api/ProductPrices/${id}`);
  }
  deleteProductImage(id: number): Observable<ProductImageModel> {
    return this.http.delete<ProductImageModel>(`${AppConstants.apiUrl}/api/ProductImages/${id}`);
  }
  deleteProductSpec(id: number): Observable<ProductSpecModel> {
    return this.http.delete<ProductSpecModel>(`${AppConstants.apiUrl}/api/ProductSpecs/${id}`);
  }
  uploadImage(id: number, f: File): Observable<ImagePathResponse> {
    const formData = new FormData();

    formData.append('file', f);
    //console.log(f);
    return this.http.post<ImagePathResponse>(`${AppConstants.apiUrl}/api/Images/${id}`, formData);
  }
}

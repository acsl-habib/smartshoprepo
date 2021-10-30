import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConstants } from '../../config/app-constants';
import { SubcategoryModel } from '../../models/data/subcategory-model';

@Injectable({
  providedIn: 'root'
})
export class SubcategoryService {

  constructor(private http: HttpClient) { }
  get(): Observable<SubcategoryModel[]> {
    return this.http.get<SubcategoryModel[]>(`${AppConstants.apiUrl}/api/Subcategories`);
  }
  getById(id: number): Observable<SubcategoryModel> {
    return this.http.get<SubcategoryModel>(`${AppConstants.apiUrl}/api/Subcategories/${id}`);
  }
  getSpecLabels(id: number): Observable<string[]> {
    return this.http.get<string[]>(`${AppConstants.apiUrl}/api/Subcategories/${id}/SpecLabels`);
  }
  create(subcategory: SubcategoryModel): Observable<SubcategoryModel> {
    return this.http.post<SubcategoryModel>(`${AppConstants.apiUrl}/api/Subcategories`, subcategory);
  }
  update(subcategory: SubcategoryModel): Observable<any> {
    
    return this.http.put<any>(`${AppConstants.apiUrl}/api/Subcategories/${subcategory.subcategoryId}`, subcategory);
  }
  delete(id: number): Observable<SubcategoryModel> {
    return this.http.delete<SubcategoryModel>(`${AppConstants.apiUrl}/api/Subcategories/${id}`);
  }
}

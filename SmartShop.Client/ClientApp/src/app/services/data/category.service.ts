import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConstants } from '../../config/app-constants';
import { CategoryModel } from '../../models/data/category-model';
import { SubcategoryModel } from '../../models/data/subcategory-model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(
    private http: HttpClient
  ) { }

  get(): Observable<CategoryModel[]> {
    return this.http.get<CategoryModel[]>(`${AppConstants.apiUrl}/api/Categories`);
  }
  getById(id: number): Observable<CategoryModel> {
    return this.http.get<CategoryModel>(`${AppConstants.apiUrl}/api/Categories/${id}`);
  }
  create(category: CategoryModel): Observable<CategoryModel> {
    return this.http.post<CategoryModel>(`${AppConstants.apiUrl}/api/Categories`, category);
  }
  update(category: CategoryModel): Observable<any> {
    return this.http.put<any>(`${AppConstants.apiUrl}/api/Categories/${category.categoryId}`, category);
  }
  delete(id: number): Observable<CategoryModel> {
    return this.http.delete<CategoryModel>(`${AppConstants.apiUrl}/api/Categories/${id}`);
  }
  getSubcategories(id: number): Observable<SubcategoryModel[]> {
    return this.http.get<SubcategoryModel[]>(`${AppConstants.apiUrl}/api/Categories/${id}/Subcategories`);
  }
}

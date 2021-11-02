import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConstants } from '../../config/app-constants';
import { CategoryModel } from '../../models/data/category-model';
import { CategoryEditModel } from '../../models/data/edit/category-edit-model';
import { CategoryInputModel } from '../../models/data/input/category-input-model';
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
  getInclude(): Observable<CategoryModel[]> {
    return this.http.get<CategoryModel[]>(`${AppConstants.apiUrl}/api/Categories/Include`);
  }
  getById(id: number): Observable<CategoryModel> {
    return this.http.get<CategoryModel>(`${AppConstants.apiUrl}/api/Categories/${id}`);
  }
  getByIdForEdit(id: number): Observable<CategoryEditModel> {
    return this.http.get<CategoryEditModel>(`${AppConstants.apiUrl}/api/Categories/${id}/ForEdit`);
  }
  create(category: CategoryModel): Observable<CategoryModel> {
    return this.http.post<CategoryModel>(`${AppConstants.apiUrl}/api/Categories`, category);
  }
  craeteWithSubcategories(category: CategoryInputModel): Observable<CategoryModel> {
    return this.http.post<CategoryModel>(`${AppConstants.apiUrl}/api/Categories/WithSubcategories`, category);
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

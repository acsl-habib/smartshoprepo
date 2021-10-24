import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConstants } from 'src/app/config/app-constants';
import { SizeModel } from 'src/app/models/data/size-model';

@Injectable({
  providedIn: 'root'
})
export class SizeService {

  constructor(
    private http:HttpClient
  ) { }
  get():Observable<SizeModel[]>{
    return this.http.get<SizeModel[]>(`${AppConstants.apiUrl}/api/Sizes`);
  }
  getSizeById(id: number): Observable<SizeModel> {
    return this.http.get<SizeModel>(`${AppConstants.apiUrl}/api/Sizes/${id}`);
  }
  
  //create Size
  createSize(Size: SizeModel): Observable<SizeModel> {
    return this.http.post<SizeModel>(`${AppConstants.apiUrl}/api/Sizes`, Size);
  }

  //Edit Size
  editSize(Size: SizeModel): Observable<any> {
    return this.http.put<any>(`${AppConstants.apiUrl}/api/Sizes/${Size.sizeId}`, Size);
  }
  //delete Size
  deleteSize(id: number): Observable<SizeModel> {
    return this.http.delete<SizeModel>(`${AppConstants.apiUrl}/api/Sizes/${id}`);
  }
}

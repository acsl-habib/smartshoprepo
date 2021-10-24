import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConstants } from 'src/app/config/app-constants';
import { BrandModel } from 'src/app/models/data/brand-model';

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
}

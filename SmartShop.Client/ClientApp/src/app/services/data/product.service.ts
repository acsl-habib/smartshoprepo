import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(
    private http: HttpClient
  ) { }
  get() { }
  getById() { }
  getInclude() { }
  getSizes() { }
  getColors() { }
  getImages() { }
  save() { }
  update() { }
  delete() {}

}

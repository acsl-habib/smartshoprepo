import { Injectable } from '@angular/core';
import { HttpClient } from '@microsoft/signalr';

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

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagingation } from '../shared/models/pagination';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  // tslint:disable-next-line: typedef
  getProducts() {
    return this.http.get<IPagingation>(this.baseUrl + 'products?pageSize=50'); // this returns all of them (or the max 50 if we had 50)
    // return this.http.get<IPagingation>(this.baseUrl + 'products'); // this returns less items - 6 as we specified that as the default fro retival from the A?I

  }
}

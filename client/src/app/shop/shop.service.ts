import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { IPagingation } from '../shared/models/pagination';
import { IType } from '../shared/models/productType';
import { map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }
  // tslint:disable-next-line: typedef
  getProducts(brandId?: number, typeId?: number, sort?: string) {
    let params = new HttpParams();

    if (brandId) {
      params = params.append('brandId', brandId.toString());
    }
    if (typeId) {
      params = params.append('typeId', typeId.toString());
    }
    if (sort) {
      params = params.append('sort', sort);
    }

    return this.http.get<IPagingation>(this.baseUrl + 'products', {observe: 'response', params})
      .pipe(
        map(response => {
          return response.body;
        })
      );
    }
    // this way were getting back an observable which we can interact with to project the body
    // into the iPagination object, therefore we use an RXJS method pipe()
    // to map it into an iPagination object
    // we use pipe to wrap any rxjs operators, we can add multipe rxjs operators in one pipe to manipulate the observable.

  // doing it like this returns us the http response
  // return this.http.get<IPagingation>(this.baseUrl + 'products', {observe: 'response', params});
  // as oppoesed to this which gives us the body of the response automatically
  // return this.http.get<IBrand[]>(this.baseUrl + 'products/brands');

  // tslint:disable-next-line: typedef
  getTypes() {
    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands');
  }

  // tslint:disable-next-line: typedef
  getBrands() {
    return this.http.get<IType[]>(this.baseUrl + 'products/types');
  }
}

import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { IPagingation, Pagination } from '../shared/models/pagination';
import { IType } from '../shared/models/productType';
import { map } from 'rxjs/operators';
import { ShopParams } from '../shared/models/shopParams';
import { IProduct } from '../shared/models/product';
import { of } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';
  products: IProduct[] = [];
  brands: IBrand[] = [];
  types: IType[] = [];
  pagination = new Pagination();
  shopParams = new ShopParams();

  constructor(private http: HttpClient) { }
  // tslint:disable-next-line: typedef
  getProducts() {
    console.log('get products this.shopParams', this.shopParams);
    // when we create a typescript class we can use them as classes themselved, that we create new instances of
    // but we can also use them as types. i.e. this.shopParams: this.shopParams (this indicates the type)
    let params = new HttpParams();

    if (this.shopParams.brandId !== 0) {
      params = params.append('brandId', this.shopParams.brandId.toString());
    }
    if (this.shopParams.typeId !== 0) {
      params = params.append('typeId', this.shopParams.typeId.toString());
    }
    if (this.shopParams.search) {
      params = params.append('search', this.shopParams.search);
    }
    params = params.append('sort', this.shopParams.sort);
    params = params.append('pageIndex', this.shopParams.pageNumber.toString());
    params = params.append('pageIndex', this.shopParams.pageSize.toString());

    return this.http.get<IPagingation>(this.baseUrl + 'products', {observe: 'response', params})
      .pipe(
        map(response => {
          this.products = [...this.products, ...response.body.data];
          this.pagination = response.body;
          return this.pagination;
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
  setShopParams(params: ShopParams){
    this.shopParams = params;
  }

  // tslint:disable-next-line: typedef
  getShopParams() {
    return this.shopParams;
  }
  // tslint:disable-next-line: typedef
  getProduct(id: number) {
    const product = this.products.find(p => p.id === id);
    console.log({id});

    if ( product ){
      return of(product);
    }
    return this.http.get<IProduct>(this.baseUrl + 'products/' + id );
  }

  // tslint:disable-next-line: typedef
  getTypes() {
    if (this.types.length > 0 ){
      return of(this.types);
    }
    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands').pipe(
      map(response => {
        this.brands = response;
        return response;
      })
    );
  }

  // tslint:disable-next-line: typedef
  getBrands() {
    if (this.brands.length > 0 ){
      return of(this.brands);
    }
    return this.http.get<IType[]>(this.baseUrl + 'products/types').pipe(
      map(response => {
        this.types = response;
        return response;
      })
    );
  }
}

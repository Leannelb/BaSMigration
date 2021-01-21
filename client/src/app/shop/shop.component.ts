import { ValueConverter } from '@angular/compiler/src/render3/view/template';
import { Component, OnInit } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { IProduct } from '../shared/models/product';
import { IType } from '../shared/models/productType';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  products: IProduct[];
  brands: IBrand[];
  types: IType[];
  brandIdSelected = 0;
  typeIdSelected = 0;
  sortSelected = 'name';
  // by initialising the typeIdSelected and brandIdSelected to 0, the 'all' filter is selected on the page;
  sortOptions = [
    {name: 'Alphabetical', value: 'name'},
    {name: 'Price: Low to High', value: 'priceAsc'},
    {name: 'Price: High to Low', value: 'priceDesc'}
  ];

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  // tslint:disable-next-line: typedef
  getProducts() {
    this.shopService.getProducts(this.brandIdSelected, this.typeIdSelected, this.sortSelected).subscribe(response => {
      this.products = response.data;
    }, error => {
      console.log('error shop component from service call ', error);
    });
  }

  // tslint:disable-next-line: typedef
  getBrands() {
    this.shopService.getBrands().subscribe(response => {
      this.brands = [{id: 0, name: 'All'}, ...response];
    }, error => {
        console.log('error from get brands API call ', error);
    });
  }

  // tslint:disable-next-line: typedef
  getTypes() {
    this.shopService.getTypes().subscribe(response => {
      this.types = [{id: 0, name: 'All'}, ...response];
    }, error => {
      console.log('error from types API call ', error);
    });
  }

  // tslint:disable-next-line: typedef
  onBrandsSelected(brandId: number) {
    this.brandIdSelected = brandId;
    this.getProducts();
  }

  // tslint:disable-next-line: typedef
  onTypeSelected(typeId: number) {
    this.typeIdSelected = typeId;
    this.getProducts();
  }

  // tslint:disable-next-line: typedef
  onSortSelected(sort: string) {
    this.sortSelected = sort;
    this.getProducts();
  }
}

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BasketService } from 'src/app/basket/basket.service';
import { IProduct } from 'src/app/shared/models/product';
import { BreadcrumbService } from 'xng-breadcrumb';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  product: IProduct;
  quantity = 1;

  constructor(private shopService: ShopService,
              private activatedRoute: ActivatedRoute,
              private breadcrumbService: BreadcrumbService,
              private basketService: BasketService ) {
    this.breadcrumbService.set('@productDetails', '');
   }
   // 113 adding this to the constructor should have stopped the numbers showing until the page is ready.... TODO come back to this

  ngOnInit(): void {
    this.loadProduct();
  }

  // tslint:disable-next-line: typedef
  loadProduct() {
    this.shopService.getProduct(+this.activatedRoute.snapshot.paramMap.get('id')).subscribe(product => {
      this.product = product;
      this.breadcrumbService.set('@productDetails', product.name);
    }, error => {
      console.log(error);
    });
  }
  // tslint:disable-next-line: typedef
  addItemToBasket(){
    this.basketService.addItemToBasket(this.product, this.quantity);
  }
  // tslint:disable-next-line: typedef
  incrementQuantity() {
    this.quantity++;
  }
  // tslint:disable-next-line: typedef
  decrementQuantity() {
    if (this.quantity > 1){
          this.quantity --;
    }
  }
}

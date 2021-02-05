import { Component, Input, OnInit } from '@angular/core';
import { BasketService } from 'src/app/basket/basket.service';
import { IProduct } from 'src/app/shared/models/product';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent implements OnInit {
  @Input() product: IProduct;

  // To recieve something from the parent - shop.component
  // need to add an input property to accept the input from the parent

  constructor(private basketService: BasketService) { }

  ngOnInit(): void {
  }

  // tslint:disable-next-line: typedef
  addItemToBasket() {
    this.basketService.addItemToBasket(this.product);
  }
}

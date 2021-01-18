import { Component, Input, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent implements OnInit {

  // To recieve something from the parent - shop.component
  // need to add an input property to accept the input from the parent

  @Input() product: IProduct;

  constructor() { }

  ngOnInit(): void {
  }

}

import { Component, OnInit } from '@angular/core';
import { BasketService } from './basket/basket.service';
import { IProduct } from './shared/models/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  constructor(private basketService: BasketService) {}
  title = 'client';
  const basketId = localStorage.getItem('basket_id');

  ngOnInit(): void {}
      if(basketId) {
    this.basketService.getBasket(basketId).subscribe(() => {
      console.log('initalised basket');
    }, error => {
      console.log('error ' , error);
    });
    }
}



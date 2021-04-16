import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { BasketService } from 'src/app/basket/basket.service';
import { IBasket, IBasketItem } from '../../models/basket';
import { IOrderItem } from '../../models/order';

@Component({
  selector: 'app-basket-summary',
  templateUrl: './basket-summary.component.html',
  styleUrls: ['./basket-summary.component.scss']
})
export class BasketSummaryComponent implements OnInit {
  @Output() decrement: EventEmitter<IBasketItem> = new EventEmitter <IBasketItem>();
  @Output() increment: EventEmitter<IBasketItem> = new EventEmitter <IBasketItem>();
  @Output() remove: EventEmitter<IBasketItem> = new EventEmitter <IBasketItem>();
  @Input() isBasket = true;
  // this is just for styling.
  @Input() isOrder = true;
  // union type IBasketItem or IOrderItem
  @Input() items: IBasketItem[] | IOrderItem[] = [];
  
  constructor() { }





  ngOnInit(): void {}

  // tslint:disable-next-line: typedef
  decrementItemQuantity(item: IBasketItem) {
    this.decrement.emit(item);
  }

  // tslint:disable-next-line: typedef
  incrementItemQuantity(item: IBasketItem) {
    this.increment.emit(item);
  }

  removeBasketItem(item: IBasketItem) {
    this.remove.emit(item);
  }
}

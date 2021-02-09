import { v4 as uuidv4 } from 'uuid';

export interface IBasket {
    id: string;
    items: IBasketItem[];
  }

export interface IBasketItem {
    id: number;
    productName: string;
    price: number;
    quantity: number;
    pictureUrl: string;
    brand: string;
    type: string;
}

export class Basket implements IBasket {
    id = uuidv4();
    items: IBasketItem[] = [];
}
// installed npm install uuid to get unique IDs for baskets
export interface IBasketTotals  {
    shipping: number;
    subtotal: number;
    total: number;
}
// 
import { Component, Input, OnInit } from '@angular/core';
import { IProduct } from '../shared/models/product';
import { BasketService } from './basket.service';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})
export class BasketComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  
 

}

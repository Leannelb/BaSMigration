import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IPagingation } from './models/pagination';
import { IProduct } from './models/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'client';
  products: IProduct[];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.http.get('https://localhost:5001/api/products').subscribe(
      (response: IPagingation) => {
      console.log(response);
      this.products = response.data;
    }, error => {
      console.log(error);
    });
  }
}



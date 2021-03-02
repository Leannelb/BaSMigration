import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PagerComponent } from './components/pager/pager.component';
import { OrderTotalsComponent } from './components/order-totals/order-totals.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [PagingHeaderComponent, PagerComponent, OrderTotalsComponent],
  imports: [
    CommonModule,
    PaginationModule.forRoot()
  ],
  // we add for root because the PaginationModule has it's own providers array that need to be injected into the root at startup.
  exports: [
    PaginationModule,
    PagingHeaderComponent,
    PagerComponent,
    OrderTotalsComponent,
    ReactiveFormsModule
  ]
})
export class SharedModule { }

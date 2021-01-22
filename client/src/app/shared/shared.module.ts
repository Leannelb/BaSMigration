import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';

@NgModule({
  declarations: [PagingHeaderComponent],
  imports: [
    CommonModule,
    PaginationModule.forRoot()
  ],
  // we add for root because the PaginationModule has it's own providers array that need to be injected into the root at startup.
  exports: [
    PaginationModule,
    PagingHeaderComponent
  ]
})
export class SharedModule { }

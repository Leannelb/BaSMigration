import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    PaginationModule.forRoot()
  ],
  // we add for root because the PaginationModule has it's own providers array that need to be injected into the root at startup.
  exports: [
    PaginationModule
  ]
})
export class SharedModule { }

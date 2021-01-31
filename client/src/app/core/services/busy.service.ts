import { identifierModuleUrl } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class BusyService {
  busyRequestCount = 0;

  constructor(private spinnerService: NgxSpinnerService) { }

  busy() {
    this.busyRequestCount++;
    this.spinnerService.show(undefined, {
      type: 'timer',
      bdColor: 'rgba(225,225,225,0.7)',
      color: '#33333'
    });
  }

  idle() {
    if (this.busyRequestCount <=0) {
      this.busyRequestCount = 0;
      this.spinnerService.hide();
    }
  }
}

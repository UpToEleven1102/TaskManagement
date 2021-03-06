import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToastComponent } from './components/toast/toast.component';
import {NgbToastModule} from '@ng-bootstrap/ng-bootstrap';



@NgModule({
  declarations: [ToastComponent],
  exports: [
    ToastComponent
  ],
  imports: [
    CommonModule, NgbToastModule
  ]
})
export class SharedModule { }

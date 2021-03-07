import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToastComponent } from './components/toast/toast.component';
import {NgbToastModule} from '@ng-bootstrap/ng-bootstrap';
import { LoadingComponent } from './components/loading/loading.component';



@NgModule({
  declarations: [ToastComponent, LoadingComponent],
  exports: [
    ToastComponent,
    LoadingComponent
  ],
  imports: [
    CommonModule, NgbToastModule
  ]
})
export class SharedModule { }

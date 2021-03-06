import { Component, OnInit } from '@angular/core';
import {ToastService} from '../../../core/services/toast.service';

@Component({
  selector: 'app-toast',
  templateUrl: './toast.component.html',
  styleUrls: ['./toast.component.css']
})
export class ToastComponent implements OnInit {

  constructor(public toastService: ToastService) { }

  ngOnInit(): void {
  }

}
import { Component, OnInit } from '@angular/core';
import { ToastService } from '../../core/services/toast.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  constructor(protected toastService: ToastService) {}

  ngOnInit(): void {}

  openToast(): void {
    this.toastService.show('Test Toast', 'Hello World');
  }
}

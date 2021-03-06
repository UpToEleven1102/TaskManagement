import { Component, OnInit } from '@angular/core';
import { ToastService } from './core/services/toast.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'TaskManagementSPA';

  constructor(protected toastService: ToastService) {}

  ngOnInit(): void {
    this.toastService.show('Welcome!', 'Welcome to Task Manager!');
  }
}

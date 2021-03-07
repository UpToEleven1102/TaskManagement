import { Component, OnInit } from '@angular/core';
import { ToastService } from '../../core/services/toast.service';
import { ApiService } from '../../core/services/api.service';
import { User } from '../../shared/types';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  users!: User[];
  constructor(protected api: ApiService) {}

  ngOnInit(): void {
    this.api.getUsers().subscribe((res) => {
      console.log(res);
      this.users = res;
    });
  }
}

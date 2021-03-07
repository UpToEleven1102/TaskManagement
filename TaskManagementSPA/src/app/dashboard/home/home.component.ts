import {Component, OnDestroy, OnInit} from '@angular/core';
import { ToastService } from '../../core/services/toast.service';
import { ApiService } from '../../core/services/api.service';
import { Dashboard, User } from '../../shared/types';
import { Subject, Subscription } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit, OnDestroy {
  dashboard?: Dashboard;
  subscription = new Subject();
  constructor(protected api: ApiService) {}

  ngOnInit(): void {
    this.api
      .getDashboard()
      .pipe(takeUntil(this.subscription))
      .subscribe((res) => {
        console.table(res.topTaskUsers);
        this.dashboard = res;
      });
  }

  ngOnDestroy(): void {
    this.subscription.next();
    this.subscription.complete();
  }
}

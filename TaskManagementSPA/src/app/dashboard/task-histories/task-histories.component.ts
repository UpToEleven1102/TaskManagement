import { Component, OnDestroy, OnInit } from '@angular/core';
import { ApiService } from '../../core/services/api.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { PaginationType, TaskHistory } from '../../shared/types';
import {ToastService} from '../../core/services/toast.service';

@Component({
  selector: 'app-task-histories',
  templateUrl: './task-histories.component.html',
  styleUrls: ['./task-histories.component.css'],
})
export class TaskHistoriesComponent implements OnInit, OnDestroy {
  private subscription = new Subject();

  page: PaginationType<TaskHistory> = {
    pageCount: 0,
    pageSize: 10,
    currentPage: 0,
    data: [],
  };

  taskHistories?: Array<TaskHistory>;
  constructor(public api: ApiService, private toast: ToastService) {}

  deleteSuccess(success: boolean): void {
    if(success) {
      this.fetchData();
    } else {
      this.toast.show('Error!', 'Something went wrong!');
    }
  }

  ngOnInit(): void {
    this.fetchData();
  }

  ngOnDestroy(): void {
    this.subscription.next();
    this.subscription.complete();
  }

  private fetchData(): void {
    this.subscription.next();
    this.subscription.complete();
    this.api
      .getTaskHistories()
      .pipe(takeUntil(this.subscription))
      .subscribe((res) => {
        this.taskHistories = res;
      });
  }
}

import { Component, OnDestroy, OnInit } from '@angular/core';
import { ApiService } from '../../core/services/api.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { PaginationType, TaskHistory } from '../../shared/types';

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
  constructor(public api: ApiService) {}

  ngOnInit(): void {
    this.api
      .getTaskHistories()
      .pipe(takeUntil(this.subscription))
      .subscribe((res) => {
        this.taskHistories = res;
      });
  }

  ngOnDestroy(): void {
    this.subscription.next();
    this.subscription.complete();
  }
}

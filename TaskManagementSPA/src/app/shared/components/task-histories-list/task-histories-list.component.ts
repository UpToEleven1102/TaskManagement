import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { TaskHistory } from '../../types';
import { ApiService } from '../../../core/services/api.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-task-histories-list',
  templateUrl: './task-histories-list.component.html',
  styleUrls: ['./task-histories-list.component.css'],
})
export class TaskHistoriesListComponent implements OnInit {
  @Input() taskHistories!: TaskHistory[];
  @Output() onDeleteSuccess = new EventEmitter();
  subscription = new Subject();
  constructor(private api: ApiService) {}

  ngOnInit(): void {}

  deleteTaskHistory(id: number): void {
    this.api
      .deleteTaskHistory(id)
      .pipe(takeUntil(this.subscription))
      .subscribe(
        (res) => {
          this.onDeleteSuccess.emit(true);
        },
        (error) => this.onDeleteSuccess.emit(false)
      );
  }
}

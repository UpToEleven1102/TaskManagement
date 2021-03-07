import {Component, Input, OnDestroy, OnInit} from '@angular/core';
import { NgbActiveModal, NgbCalendar, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import {Task, User} from '../../../shared/types';
import { ApiService } from '../../../core/services/api.service';
import { ToastService } from '../../../core/services/toast.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-new-task-modal',
  templateUrl: './new-task-modal.component.html',
  styleUrls: ['./new-task-modal.component.css'],
})
export class NewTaskModalComponent implements OnInit, OnDestroy {
  @Input() task!: Task;
  users?: User[];
  loading = false;
  dueDateModel!: NgbDateStruct;
  subscription = new Subject();
  date?: any;
  constructor(
    public activeModal: NgbActiveModal,
    private api: ApiService,
    private calendar: NgbCalendar,
    private toast: ToastService
  ) {}

  ngOnInit(): void {
    this.api.getUsers().pipe(takeUntil(this.subscription)).subscribe(res => this.users = res);
    if (!this.task) {
      this.task = { description: '', dueDate: '', priority: '3', remarks: '', title: '' };
    } else {
      delete this.task.user;
    }
    this.dueDateModel = this.calendar.getToday();
  }

  ngOnDestroy(): void {
    this.subscription.next();
    this.subscription.complete();
  }

  postTask(): void {
    if (!this.task.title || !this.task.description) {
      return this.toast.show('Error!', 'Title and description are required');
    }

    if (!this.task.userId) {
      return this.toast.show('Error!', 'Task should be assigned to an user!');
    }

    this.task.dueDate = new Date(this.dueDateModel.year, this.dueDateModel.month, this.dueDateModel.day).toISOString();
    (this.task.id ? this.api.putTask(this.task) : this.api.postTask(this.task))
      .pipe(takeUntil(this.subscription))
      .subscribe((res) => {
        this.activeModal.close(true);
      }, () => {
        this.toast.show('Error!', 'Something went wrong!');
      });
  }
}

import { Component, OnDestroy, OnInit } from '@angular/core';
import { ApiService } from '../../core/services/api.service';
import { Task, User } from '../../shared/types';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { ToastService } from '../../core/services/toast.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { NewTaskModalComponent } from './new-task-modal/new-task-modal.component';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css'],
})
export class TasksComponent implements OnInit, OnDestroy {
  tasks?: Task[];
  users?: User[];
  subscription = new Subject();

  constructor(private api: ApiService, private toast: ToastService, private modalService: NgbModal) {}

  private fetchData(): void {
    this.subscription.next();
    this.subscription.complete();
    this.api
      .getTasks()
      .pipe(takeUntil(this.subscription))
      .subscribe(
        (res) => {
          this.tasks = res;
        },
        () => {
          this.toast.show('Error!', 'Something went wrong!');
        }
      );
  }

  ngOnInit(): void {
    this.fetchData();
    this.api
      .getUsers()
      .pipe(takeUntil(this.subscription))
      .subscribe((res) => (this.users = res));
  }

  ngOnDestroy(): void {
    this.subscription.next();
    this.subscription.complete();
  }

  openNewTaskModal(): void {
    const modalRef = this.modalService.open(NewTaskModalComponent);
    modalRef.result.then((res) => {
      if (res) {
        this.fetchData();
      }
    });
    modalRef.componentInstance.users = this.users;
  }

  archiveSuccess(success: boolean): void {
    if (success) {
      this.fetchData();
      this.toast.show('Success!', 'Archived the task!');
    } else {
      this.toast.show('Error!', 'Something went wrong!');
    }
  }

  deleteSuccess(success: boolean): void {
    if (success) {
      this.fetchData();
      this.toast.show('Success!', 'Deleted the task!');
    } else {
      this.toast.show('Error!', 'Something went wrong!');
    }
  }

  editSuccess(success: boolean): void {
    if (success) {
      this.fetchData();
    }
  }
}

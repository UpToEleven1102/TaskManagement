import { Component, OnDestroy, OnInit } from '@angular/core';
import { ApiService } from '../../core/services/api.service';
import { Task } from '../../shared/types';
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
  }

  ngOnDestroy(): void {
    this.subscription.next();
    this.subscription.complete();
  }

  completeTask(id: number): void {
    this.subscription.next();
    this.subscription.complete();
    this.api
      .completeTask(id)
      .pipe(takeUntil(this.subscription))
      .subscribe(
        (res) => {
          this.fetchData();
          this.toast.show('Success!', 'Archived the task!');
        },
        () => {
          this.toast.show('Error!', 'Something went wrong!');
        }
      );
  }

  openNewTaskModal(): void {
    const modalRef = this.modalService.open(NewTaskModalComponent);
    modalRef.result.then((res) => {
      console.log(res);
      if (res) {
        this.fetchData();
      }
    });
  }
}

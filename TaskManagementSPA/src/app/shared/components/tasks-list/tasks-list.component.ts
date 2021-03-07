import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { Task, User } from '../../types';
import { NewTaskModalComponent } from '../../../dashboard/tasks/new-task-modal/new-task-modal.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { takeUntil } from 'rxjs/operators';
import { ApiService } from '../../../core/services/api.service';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-tasks-list',
  templateUrl: './tasks-list.component.html',
  styleUrls: ['./tasks-list.component.css'],
})
export class TasksListComponent implements OnDestroy {
  @Input() tasks!: Task[];
  @Input() users!: User[];
  @Output() onEditSuccess: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Output() onArchiveSuccess: EventEmitter<boolean> = new EventEmitter<boolean>();

  subscription = new Subject();

  constructor(private modalService: NgbModal, private api: ApiService) {}

  ngOnDestroy(): void {
    this.subscription.next();
    this.subscription.complete();
  }

  openEditTask(task: Task): void {
    task.userId = task.user?.id;
    const modalRef = this.modalService.open(NewTaskModalComponent);
    modalRef.result.then((res) => {
      if (res) {
        return this.onEditSuccess.emit(true);
      }
      this.onEditSuccess.emit(false);
    });
    modalRef.componentInstance.task = { ...task };
    modalRef.componentInstance.users = this.users;
  }

  completeTask(id: number): void {
    this.subscription.next();
    this.subscription.complete();
    this.api
      .completeTask(id)
      .pipe(takeUntil(this.subscription))
      .subscribe(
        (res) => {
          this.onArchiveSuccess.emit(true);
        },
        () => {
          this.onArchiveSuccess.emit(false);
        }
      );
  }
}

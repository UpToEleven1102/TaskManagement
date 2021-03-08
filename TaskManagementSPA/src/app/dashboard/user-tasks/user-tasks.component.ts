import { Component, OnDestroy, OnInit } from '@angular/core';
import { User } from '../../shared/types';
import { ActivatedRoute } from '@angular/router';
import { ApiService } from '../../core/services/api.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { ToastService } from '../../core/services/toast.service';

@Component({
  selector: 'app-user-tasks',
  templateUrl: './user-tasks.component.html',
  styleUrls: ['./user-tasks.component.css'],
})
export class UserTasksComponent implements OnInit, OnDestroy {
  users?: User[];
  user?: User;
  subscription = new Subject();

  constructor(private route: ActivatedRoute, private api: ApiService, private toast: ToastService) {}

  private fetchData(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      const sub = this.api.getUsers().subscribe((res) => {
        this.users = res;
        sub.unsubscribe();
      });

      this.subscription.next();
      this.subscription.complete();
      this.api
        .getUserById(id)
        .pipe(takeUntil(this.subscription))
        .subscribe((res) => (this.user = res));
    }
  }

  ngOnInit(): void {
    this.fetchData();
  }

  ngOnDestroy(): void {
    this.subscription.next();
    this.subscription.complete();
  }

  archiveSuccess(success: boolean): void {
    if (success) {
      this.fetchData();
      this.toast.show('Success!', 'Archived the task!');
    } else {
      this.toast.show('Error!', 'Something went wrong!');
    }
  }

  editSuccess(success: boolean): void {
    if (success) {
      this.fetchData();
    }
  }

  deleteSuccess(success: boolean): void {
    if(success) {
      this.fetchData();
    } else {
      this.toast.show('Error!', 'Something went wrong!');
    }
  }
}

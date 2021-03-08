import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { ApiService } from '../../core/services/api.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { User } from '../../shared/types';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { NewUserModalComponent } from '../user-detail/new-user-modal/new-user-modal.component';
import { ToastService } from '../../core/services/toast.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
})
export class UsersComponent implements OnInit, OnDestroy {
  subscription = new Subject();
  showUserId?: number;
  users?: User[];

  constructor(protected api: ApiService, private modalService: NgbModal, private toast: ToastService) {}

  ngOnInit(): void {
    this.fetchData();
  }

  ngOnDestroy(): void {
    this.subscription.next();
    this.subscription.complete();
  }

  openNewUserModal(): void {
    const modalRef = this.modalService.open(NewUserModalComponent);
    modalRef.result.then((result) => {
      if (result === true) {
        this.fetchData();
      }
    });
    modalRef.componentInstance.noBackButton = true;
  }

  viewTaskHistories(user: User): void {
    this.showUserId = this.showUserId === user.id ? undefined : user.id;
  }

  removeUser(id: number): void {
    const sub = this.api.deleteUser(id).subscribe(
      (res) => {
        this.fetchData();
        sub.unsubscribe();
      },
      (error) => {
        this.toast.show('Error!', 'Something went wrong!');
        this.toast.show('Error!', 'You might wanna delete all tasks and task histories related to the user first!');
      }
    );
  }

  deleteSuccess(success: boolean): void {
    if (success) {
      this.fetchData();
    } else {
      this.toast.show('Error!', 'Something went wrong!');
    }
  }

  private fetchData(): void {
    this.subscription.next();
    this.subscription.complete();
    this.api
      .getUsers()
      .pipe(takeUntil(this.subscription))
      .subscribe((res) => {
        console.log(res);
        this.users = res;
      });
  }
}

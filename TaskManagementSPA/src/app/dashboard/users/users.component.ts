import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { ApiService } from '../../core/services/api.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { User } from '../../shared/types';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { NewUserModalComponent } from '../user-detail/new-user-modal/new-user-modal.component';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
})
export class UsersComponent implements OnInit, OnDestroy {
  subscription = new Subject();
  showUserId?: number;
  users?: User[];

  constructor(protected api: ApiService, private modalService: NgbModal) {}

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

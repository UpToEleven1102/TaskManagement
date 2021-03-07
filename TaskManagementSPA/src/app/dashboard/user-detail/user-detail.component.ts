import {Component, Input, OnDestroy, OnInit} from '@angular/core';
import { UserRequest } from '../../shared/types';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from '../../core/services/api.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { ToastService } from '../../core/services/toast.service';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css'],
})
export class UserDetailComponent implements OnInit, OnDestroy {
  @Input() noBackButton = false;
  @Input() close?: () => void;
  loading = false;
  user: UserRequest = { email: '', fullName: '', mobileNo: '', password: '' };
  subscription = new Subject();
  constructor(private route: ActivatedRoute, private api: ApiService, private toast: ToastService) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');

    if (id) {
      this.api
        .getUserById(id)
        .pipe(takeUntil(this.subscription))
        .subscribe((res) => {
          delete res.taskHistories;
          delete res.tasks;
          this.user = res;
        });
    }
  }

  ngOnDestroy(): void {
    this.subscription.next();
    this.subscription.complete();
  }

  async postUser(): Promise<void> {
    this.loading = true;
    try {
      (this.user.id ? this.api.putUser(this.user) : this.api.postUser(this.user)).subscribe(res => {
        console.log(res);
      });
      this.toast.show('Success!', 'Saved user info!');
    } catch (e) {
      console.log(e);
      this.toast.show('Error!', 'Something went wrong!');
    } finally {
      this.loading = false;
    }
  }
}

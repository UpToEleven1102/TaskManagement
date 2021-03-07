import {Component, EventEmitter, Input, OnDestroy, OnInit, Output} from '@angular/core';
import { UserRequest } from '../../shared/types';
import { ActivatedRoute } from '@angular/router';
import { ApiService } from '../../core/services/api.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { ToastService } from '../../core/services/toast.service';
import { Location } from '@angular/common'

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css'],
})
export class UserDetailComponent implements OnInit, OnDestroy {
  @Input() noBackButton = false;
  @Input() close?: () => void;
  @Output() onSuccess: EventEmitter<boolean> = new EventEmitter<boolean>();

  loading = false;
  user: UserRequest = { email: '', fullName: '', mobileNo: '', password: '' };
  subscription = new Subject();
  constructor(
    private location: Location,
    private route: ActivatedRoute,
    private api: ApiService,
    private toast: ToastService
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');

    if (id) {
      this.loading = true;
      this.api
        .getUserById(id)
        .pipe(takeUntil(this.subscription))
        .subscribe(
          (res) => {
            delete res.taskHistories;
            delete res.tasks;
            this.user = res;
            this.loading = false;
          },
          () => {
            this.toast.show('Error!', 'Invalid user id');
            this.loading = false;
          }
        );
    }
  }

  ngOnDestroy(): void {
    this.subscription.next();
    this.subscription.complete();
  }

  async postUser(): Promise<void> {
    this.loading = true;
    try {
      if (this.user.password === '') delete this.user.password;
      (this.user.id ? this.api.putUser(this.user) : this.api.postUser(this.user)).subscribe(
        (res) => {
          this.toast.show('Success!', 'Saved user info!');
          if (this.close) {
            this.onSuccess.emit(true);
          } else {
            this.location.back();
          }
        },
        (errors) => {
          if (errors) {
            for (const err of Object.keys(errors)) {
              for (const message of errors[err]) {
                this.toast.show('Error!', message);
              }
            }
          } else {
            this.toast.show('Error!', 'Something went wrong!');
          }
        }
      );
    } catch (e) {
      console.log(e);
      this.toast.show('Error!', 'Something went wrong!');
    } finally {
      this.loading = false;
    }
  }
}

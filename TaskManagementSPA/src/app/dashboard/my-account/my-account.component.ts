import { Component, OnDestroy, OnInit } from '@angular/core';
import { AuthService } from '../../core/services/auth.service';
import { User } from '../../shared/types';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-my-account',
  templateUrl: './my-account.component.html',
  styleUrls: ['./my-account.component.css'],
})
export class MyAccountComponent implements OnInit, OnDestroy {
  user?: User | null;
  editing = false;

  subscription = new Subject();

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    this.authService.currentUser
      .pipe(takeUntil(this.subscription))
      .subscribe((currentUser) => (this.user = currentUser));
  }

  ngOnDestroy(): void {
    this.subscription.complete();
  }

  onSubmit(): void {
    console.log('submit user');
  }

  onEdit(): void {
    this.editing = true;
  }

}

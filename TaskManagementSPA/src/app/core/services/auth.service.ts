import { Injectable } from '@angular/core';
import { User } from '../../shared/types';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  currentUser: BehaviorSubject<User | null> = new BehaviorSubject<User | null>(null);

  constructor() {
    setTimeout(() => {
      this.currentUser.next({
        email: 'huyen.vu@ttu.edu',
        fullName: 'Huyen Vu',
        id: 0,
        mobileNo: '8062831598',
        profileUrl:
          'https://images.unsplash.com/photo-1506980595904-70325b7fdd90?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=927&q=80',
      });
    }, 1000);
  }
}

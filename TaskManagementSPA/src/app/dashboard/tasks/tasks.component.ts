import {Component, OnDestroy, OnInit} from '@angular/core';
import {ApiService} from '../../core/services/api.service';
import {Task} from '../../shared/types';
import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {ToastService} from '../../core/services/toast.service';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit, OnDestroy {
  tasks?: Task[];
  subscription = new Subject();

  constructor(private api: ApiService, private toast: ToastService) {
  }

  ngOnInit(): void {
    this.api.getTasks().pipe(takeUntil(this.subscription)).subscribe(res => {
      this.tasks = res;
      console.log(res);
    }, () => {
      this.toast.show('Error!', 'Something went wrong!');
    });
  }

  ngOnDestroy(): void {
    this.subscription.next();
    this.subscription.complete();
  }
}

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToastComponent } from './components/toast/toast.component';
import { NgbToastModule, NgbTypeaheadModule } from '@ng-bootstrap/ng-bootstrap';
import { LoadingComponent } from './components/loading/loading.component';
import { TasksListComponent } from './components/tasks-list/tasks-list.component';
import { TaskHistoriesListComponent } from './components/task-histories-list/task-histories-list.component';
import { BackButtonComponent } from './components/back-button/back-button.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [ToastComponent, LoadingComponent, TasksListComponent, TaskHistoriesListComponent, BackButtonComponent],
  exports: [ToastComponent, LoadingComponent, TaskHistoriesListComponent, TasksListComponent, BackButtonComponent],
  imports: [CommonModule, NgbToastModule, NgbTypeaheadModule, RouterModule],
})
export class SharedModule {}

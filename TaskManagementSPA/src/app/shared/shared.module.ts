import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToastComponent } from './components/toast/toast.component';
import { NgbToastModule, NgbTypeaheadModule } from '@ng-bootstrap/ng-bootstrap';
import { LoadingComponent } from './components/loading/loading.component';
import { TasksListComponent } from './components/tasks-list/tasks-list.component';
import { TaskHistoriesListComponent } from './components/task-histories-list/task-histories-list.component';

@NgModule({
  declarations: [ToastComponent, LoadingComponent, TasksListComponent, TaskHistoriesListComponent],
  exports: [ToastComponent, LoadingComponent, TaskHistoriesListComponent],
  imports: [CommonModule, NgbToastModule, NgbTypeaheadModule],
})
export class SharedModule {}

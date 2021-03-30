import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToastComponent } from './components/toast/toast.component';
import { NgbToastModule, NgbTypeaheadModule } from '@ng-bootstrap/ng-bootstrap';
import { LoadingComponent } from './components/loading/loading.component';
import { TasksListComponent } from './components/tasks-list/tasks-list.component';
import { TaskHistoriesListComponent } from './components/task-histories-list/task-histories-list.component';
import { BackButtonComponent } from './components/back-button/back-button.component';
import { RouterModule } from '@angular/router';
import { SizeDetectorComponent } from './components/size-detector/size-detector.component';
import { FileUploaderComponent } from './components/file-uploader/file-uploader.component';

@NgModule({
  declarations: [ToastComponent, LoadingComponent, TasksListComponent, TaskHistoriesListComponent, BackButtonComponent, SizeDetectorComponent, FileUploaderComponent],
    exports: [ToastComponent, LoadingComponent, TaskHistoriesListComponent, TasksListComponent, BackButtonComponent, SizeDetectorComponent, FileUploaderComponent],
  imports: [CommonModule, NgbToastModule, NgbTypeaheadModule, RouterModule],
})
export class SharedModule {}

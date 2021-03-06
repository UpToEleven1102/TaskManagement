import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { UsersComponent } from './users/users.component';
import { TasksComponent } from './tasks/tasks.component';
import { TaskHistoriesComponent } from './task-histories/task-histories.component';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';
import { CoreModule } from '../core/core.module';

@NgModule({
  declarations: [HomeComponent, UsersComponent, TasksComponent, TaskHistoriesComponent, DashboardComponent],
  exports: [DashboardComponent],
  imports: [CommonModule, DashboardRoutingModule, CoreModule],
})
export class DashboardModule {}

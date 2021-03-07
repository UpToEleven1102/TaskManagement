import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { UsersComponent } from './users/users.component';
import { TasksComponent } from './tasks/tasks.component';
import { TaskHistoriesComponent } from './task-histories/task-histories.component';
import { UserDetailComponent } from './user-detail/user-detail.component';

const routes: Routes = [
  { path: 'app', component: HomeComponent },
  {
    path: 'app/users',
    component: UsersComponent,
  },
  { path: 'app/users/:id', component: UserDetailComponent },
  { path: 'app/tasks', component: TasksComponent },
  { path: 'app/task-histories', component: TaskHistoriesComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class DashboardRoutingModule {}

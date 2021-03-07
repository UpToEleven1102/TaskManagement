import {Task} from 'protractor/built/taskScheduler';

export type TaskHistory = {
  taskId: number;
  userId: number;
  title: string;
  description: string;
  dueDate: string;
  completed: string;
  remarks: string;
  user: User;
};

export type User = {
  id: number;
  email: string;
  fullName: string;
  mobileNo: string;
  tasks: Task[];
  taskHistories: TaskHistory[];
};

export type PaginationType<T> = {
  pageCount: number;
  pageSize: number;
  currentPage: number;
  data: Array<T>
};

export type Dashboard = {
  userCount: number;
  taskCount: number;
  taskHistoryCount: number;
  topTaskUsers: User[];
  topCompletedUsers: User[];
  recentTaskHistories: TaskHistory[];
};

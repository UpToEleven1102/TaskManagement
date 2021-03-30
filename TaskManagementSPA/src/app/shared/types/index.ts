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

export type Task = {
  id?: number;
  title: string;
  description: string;
  dueDate: string;
  priority: '0' | '1' | '2' | '3' | '4' | '5';
  remarks: string;
  userId?: number;
  user?: User;
};


export type User = {
  id: number;
  email: string;
  profileUrl?: string;
  fullName: string;
  mobileNo: string;
  tasks?: Task[];
  taskHistories?: TaskHistory[];
};

export type UserRequest = {
  id?: number;
  email: string;
  fullName: string;
  mobileNo: string;
  password?: string; // for post purpose only
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

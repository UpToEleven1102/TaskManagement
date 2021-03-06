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
};

export type PaginationType<T> = {
  pageCount: number;
  pageSize: number;
  currentPage: number;
  data: Array<T>
};

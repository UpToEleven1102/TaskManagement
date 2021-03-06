import { Injectable } from '@angular/core';

export type Toast = { header: string; body: string; delay?: number };

@Injectable({
  providedIn: 'root',
})
export class ToastService {
  toasts: Toast[] = [];

  show(header: string, body: string): void {
    this.toasts.push({ header, body });
  }

  remove(toast: Toast): void {
    this.toasts = this.toasts.filter((t) => t.header !== toast.header && t.body !== toast.body);
  }
}

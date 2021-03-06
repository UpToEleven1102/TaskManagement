import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class MenuService {
  public isCollapsed = false;

  toggleMenu(): void {
    this.isCollapsed = !this.isCollapsed;
  }
}

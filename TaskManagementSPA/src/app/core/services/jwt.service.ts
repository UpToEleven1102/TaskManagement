import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class JwtService {
  TOKEN_NAME: string;
  constructor() {
    const { tokenName } = environment;
    this.TOKEN_NAME = tokenName || 'taskmanagement.token';
  }

  saveToken(token: string): void {
    localStorage.setItem(this.TOKEN_NAME, token);
  }

  getToken(): string | null {
    return localStorage.getItem(this.TOKEN_NAME);
  }

  clearToken(): void {
    localStorage.removeItem(this.TOKEN_NAME);
  }
}

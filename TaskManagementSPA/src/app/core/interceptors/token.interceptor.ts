import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';
import { JwtService } from '../services/jwt.service';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  constructor(private jwtService: JwtService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    // this.jwtService.saveToken(
    //   'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxIiwiZW1haWwiOiJodXllbi52dUB0dHUuZWR1IiwidW5pcXVlX25hbWUiOiJIdXllbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL21vYmlsZXBob25lIjoiODA2MjM0MjM0MyIsIm5iZiI6MTYxNzY1Njc1MCwiZXhwIjoxNjE3OTE1OTUwLCJpYXQiOjE2MTc2NTY3NTAsImlzcyI6Ikh1eWVuVnUuVGFza01hbmFnZW1lbnQiLCJhdWQiOiJIdXllblZ1LlRhc2tNYW5hZ2VtZW50IFVzZXJzIn0.LxRjuo44FXXgcU8agTYQLlwR5wehDUyy-44e3YmCIXU'
    // );
    const token = this.jwtService.getToken();

    if (token) {
      const headersConfig = {
        'Content-Type': 'application/json',
        Accept: 'application/json',
        Authorization: token,
      };

      return next.handle(request.clone({ setHeaders: headersConfig }));
    }

    return next.handle(request);
  }
}

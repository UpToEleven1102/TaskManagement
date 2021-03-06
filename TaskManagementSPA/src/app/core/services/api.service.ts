import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParamsOptions } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable, ObservableInput, throwError } from 'rxjs';
import { TaskHistory } from '../../shared/types';
import { catchError, map } from 'rxjs/operators';
import { ToastService } from './toast.service';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private headers: HttpHeaders;

  constructor(protected http: HttpClient, protected toast: ToastService) {
    this.headers = new HttpHeaders();
    this.headers.append('Content-Type', 'application/json');
  }

  getData(path: string): Observable<object> {
    return this.http.get(`${environment.apiUrl}${path}`).pipe(
      map((res) => res),
      catchError(this.handleError)
    );
  }

  postData(path: string, payload: object, options?: HttpParamsOptions): Observable<object> {
    return this.http.post(`${environment.apiUrl}${path}`, payload, { headers: this.headers, ...options }).pipe(
      map((res) => res),
      catchError(this.handleError)
    );
  }

  getTaskHistories(): Observable<TaskHistory[]> {
    return this.getData('task-history').pipe(map((res) => res as TaskHistory[]));
  }

  private handleError = (error: HttpErrorResponse): ObservableInput<any> =>  {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      this.toast.show('Client Error!', `An error occurred: ${error.error.message}`);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      this.toast.show('Error', error.error.errorMessage);
      this.toast.show('Server Error: ', `Backend returned code ${error.status}. body was: ${error.message}`);
    }
    // return an observable with a user-facing error message
    return throwError(error.error.errorMessage);
  }
}

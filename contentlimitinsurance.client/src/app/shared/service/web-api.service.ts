import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { map } from 'rxjs/operators';
import { catchError } from 'rxjs/operators';
import { HttpHeaders, HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class WebAPIService {
  constructor(private httpClient: HttpClient) { }

  /*
   * Get call
   */
  get(url: string): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Cache-Control': 'no-cache',
        'Pragma': 'no-cache'
      }),
      observe: (("response") as any) as 'body'
    };
    return this.httpClient.get(
        url,
        httpOptions
      )
      .pipe(
        map((response: any) => this.returnResponseData(response)),
        catchError(this.handleError)
      );
  }


  /*
   * Post call
   */
  post(url: string, model: any): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      }),
      observe: 'response' as 'body'
    };
    return this.httpClient.post<{ value: any }>(url, JSON.stringify(model), httpOptions)
      .pipe(
        map((response: any) =>
          this.returnResponseData(response)),
        catchError(this.handleError)
      );
  }

  private returnResponseData(response: any) {
    return response;
  }

  private handleError(error: any) {
    return throwError(error);
  }
}

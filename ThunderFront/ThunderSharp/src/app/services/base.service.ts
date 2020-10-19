import { Token } from './../models/token';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SignIn } from '../models/sign-in';
import { SignUp } from '../models/sign-up';
import { retry, catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BaseService {

  constructor(private httpClient: HttpClient) { }

  url = 'https://localhost:44395/api';
  httpOptions = {
    headers: new HttpHeaders({'Content-type': 'application/json'}) };

    // tslint:disable-next-line:typedef
    SignUp(signUp: SignUp){
      return this.httpClient.post(this.url + '/Register', JSON.stringify(signUp), this.httpOptions).pipe(
        catchError(this.handleError)
      );
    }

    // tslint:disable-next-line:typedef
    SignIn(signIn: SignIn){
      return this.httpClient.post(this.url + '/Login', JSON.stringify(signIn), this.httpOptions).pipe(
        catchError(this.handleError)
      );
    }
   // tslint:disable-next-line:typedef
    GetMostReservedDays(){
      return this.httpClient.get(this.url + '/Dashboard/dashboard/days', this.httpOptions).pipe(
        catchError(this.handleError)
      );
    }

    // tslint:disable-next-line:typedef
    handleError(error: HttpErrorResponse) {
      if (error.error instanceof ErrorEvent) {
        alert('Error Fatal');
      } else {
        alert('Error Fatal');
      }
      return throwError('erros');
    }
}

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

    SignUp(signUp: SignUp): any{
      return this.httpClient.post(this.url + '/Register', JSON.stringify(signUp), this.httpOptions).pipe(
        retry(2),
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
    handleError(error: HttpErrorResponse) {
      let errorMessage = '';
      if (error.error instanceof ErrorEvent) {
        errorMessage = error.error.message;
      } else {
        errorMessage = `Código do erro: ${error.status}, ` + `Erro: ${error.message}`;
      }
      console.log(errorMessage);
      return throwError(errorMessage);
    }
}

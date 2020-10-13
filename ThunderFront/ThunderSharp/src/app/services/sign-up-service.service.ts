import { SignUp } from './../models/sign-up';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class SignUpServiceService {

  constructor(private httpClient: HttpClient) { }

  url = 'http://localhost:3000/cars';
  httpOptions = {
    headers: new HttpHeaders({'Content-type': 'application/json'}) };

    SignUp(signUp: SignUp): any{
      return this.httpClient.post(this.url + '/register', JSON.stringify(signUp), this.httpOptions).pipe(
        retry(2),
        catchError(this.handleError)
      );
    }

    // tslint:disable-next-line:typedef
    handleError(error: HttpErrorResponse) {
      let errorMessage = '';
      if (error.error instanceof ErrorEvent) {
        errorMessage = error.error.message;
      } else {
        errorMessage = `Código do erro: ${error.status}, ` + `menssagem: ${error.message}`;
      }
      console.log(errorMessage);
      return throwError(errorMessage);
    }
}

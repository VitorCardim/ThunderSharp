import { Token } from './../../models/token';
import { Injectable, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
 export class HttpsRequestInterceptor implements HttpInterceptor {
  
  intercept( request: HttpRequest<any>, next: HttpHandler ): Observable<HttpEvent<any>> {
    const User: Token = JSON.parse(localStorage.getItem('UserToken'));
    console.log(User.accessToken);
    
    if (User != null){
      request = request.clone({
        setHeaders: {
          Authorization:  'Bearer ' + User.accessToken
        }
       });
    }
    return next.handle(request);
   }
  }

@NgModule({
 providers: [
  {
   provide: HTTP_INTERCEPTORS,
   useClass: HttpsRequestInterceptor,
   multi: true,
  },
 ],
 })
 export class Interceptor {}

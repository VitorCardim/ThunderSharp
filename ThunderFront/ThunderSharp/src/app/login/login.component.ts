import { Token } from './../models/token';
import { BaseService } from './../services/base.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { SignIn } from '../models/sign-in';
import jwt_decode from 'jwt-decode';
import {Router} from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public loginForm: FormGroup;
  declare TRTD: string;

  constructor(private fb: FormBuilder, private baseService: BaseService, private router: Router) {
    this.createForm();
  }
  ngOnInit(): void {
  }

  createForm(): any{
    this.loginForm = this.fb.group({
      Email: ['', Validators.email],
      Password: ['', Validators.required]
    });
  }

  loginSubmit(): any{
    const user = this.loginForm.value as SignIn;
    
    this.baseService.SignIn(user).subscribe((token: Token) =>
    {
      if (token.accessToken != null){
        // console.log(token.accessToken);
        // const decoded = jwt_decode(token.accessToken);
        // console.log(decoded);
        localStorage.setItem('UserToken', JSON.stringify(token));
        this.router.navigate(['/dashboard']);
      }
    });
  }
}

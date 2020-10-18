import { Token } from './../models/token';
import { BaseService } from './../services/base.service';
import { SignUp } from './../models/sign-up';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { SignIn } from '../models/sign-in';
import {Router} from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public loginForm: FormGroup;

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
        console.log(token.accessToken);
        localStorage.setItem('token', token.accessToken);
        this.router.navigate(['/dashboard']);
      }
    });
  }
}

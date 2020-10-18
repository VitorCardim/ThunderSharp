import { BaseService } from './../services/base.service';
import { SignUp } from './../models/sign-up';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray, FormControl } from '@angular/forms';
import { strict } from 'assert';


export interface Items{
  id: number;
  name: string;
}

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  public signUpForm: FormGroup;
  public idUser: number;

  public checkItems: Items[] = [{id: 0, name: 'Produtor'}, {id: 0, name: 'Ator/Atriz'}];

  constructor(private fb: FormBuilder, private serviceBase: BaseService ) { this.createForm(); }

  createForm(): any{
    this.signUpForm = this.fb.group({
      Email: ['', Validators.email],
      Password: ['', Validators.required],
      Name: ['', Validators.required],
      PhoneNumber: ['', Validators.required]
    });
  }

  signUpSubmit(): any{
    const user = this.signUpForm.value as SignUp;
    console.log(user);
    
    this.serviceBase.SignUp(user).subscribe((id: number) =>
    {
      this.idUser = id;
    });
  }

  onChanged(name: string, isChecked: boolean): any {
    console.log(name);
  }


  ngOnInit(): void {
  }

}

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

  public checkItems: Items[] = [{id: 0, name: 'Produtor'}, {id: 0, name: 'Ator/Atriz'}];

  constructor(private fb: FormBuilder ) { this.createForm(); }

  createForm(): any{
    this.signUpForm = this.fb.group({
      Email: ['', Validators.email],
      Password: ['', Validators.required],
      FullName: ['', Validators.required],
      PhoneNumber: ['', Validators.required],
      name: this.fb.array([])
    });
  }

  signUpSubmit(): any{
    console.log(this.signUpForm.value);
  }

  onChanged(name: string, isChecked: boolean): any {
    console.log(name);
  }


  ngOnInit(): void {
  }

}

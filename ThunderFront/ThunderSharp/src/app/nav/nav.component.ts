import { Token } from './../models/token';
import { Component, OnInit } from '@angular/core';
import jwt_decode from 'jwt-decode';
import { TokenDetails } from '../models/token-details';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  public Name: string;

  constructor() { this.getUserClaimName(); }

  ngOnInit(): void {

  }

  getUserClaimName(): any{
    const token: Token = JSON.parse(localStorage.getItem('UserToken'));
    if (token != null){
      const decoded = jwt_decode(token.accessToken) as TokenDetails;
      console.log(decoded);
      this.Name = decoded.NameUser;
    }
  }

  onClick(): any{
    console.log('chegouuu');
  }

}

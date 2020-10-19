import { Component, OnInit } from '@angular/core';
import { Actor } from '../models/actor';


@Component({
  selector: 'app-actor-home',
  templateUrl: './actor-home.component.html',
  styleUrls: ['./actor-home.component.css'],
  
})
export class ActorHomeComponent implements OnInit {

  titulo = 'Resevations';

  public reservations: Actor[] = [
    {name: '1212w', initial: '123121', final: '232323232'},
    {name: '2', initial: '223121', final: '232323232'},
    {name: '1212', initial: '123121', final: '232323232'},
    {name: '1212', initial: '123121', final: '232323232'},
    {name: '1212', initial: '123121', final: '232323232'},
    {name: '1212', initial: '123121', final: '232323232'},
    {name: '1212', initial: '123121', final: '232323232'}
  ];
  
  constructor() { }

  ngOnInit(): void {
  }

}

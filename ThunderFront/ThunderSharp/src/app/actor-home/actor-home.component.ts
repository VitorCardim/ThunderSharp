import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-actor-home',
  templateUrl: './actor-home.component.html',
  styleUrls: ['./actor-home.component.css']
})
export class ActorHomeComponent implements OnInit {

  titles = ['Production Name', 'Reservation Initial Date', 'Reservation Final Date',]; 

  constructor() { }

  ngOnInit(): void {
  }

}

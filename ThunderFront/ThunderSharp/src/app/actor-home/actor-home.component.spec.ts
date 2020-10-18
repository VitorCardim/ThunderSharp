import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActorHomeComponent } from './actor-home.component';

describe('ActorHomeComponent', () => {
  let component: ActorHomeComponent;
  let fixture: ComponentFixture<ActorHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ActorHomeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ActorHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

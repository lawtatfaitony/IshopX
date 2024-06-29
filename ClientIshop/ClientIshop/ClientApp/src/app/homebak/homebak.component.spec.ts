import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HomebakComponent } from './homebak.component';

describe('HomebakComponent', () => {
  let component: HomebakComponent;
  let fixture: ComponentFixture<HomebakComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HomebakComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HomebakComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

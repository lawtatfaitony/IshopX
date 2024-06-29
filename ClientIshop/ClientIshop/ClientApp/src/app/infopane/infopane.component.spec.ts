import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InfopaneComponent } from './infopane.component';

describe('InfopaneComponent', () => {
  let component: InfopaneComponent;
  let fixture: ComponentFixture<InfopaneComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InfopaneComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InfopaneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

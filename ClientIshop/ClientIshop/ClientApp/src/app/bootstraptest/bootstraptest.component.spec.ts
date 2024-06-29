import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BootstraptestComponent } from './bootstraptest.component';

describe('BootstraptestComponent', () => {
  let component: BootstraptestComponent;
  let fixture: ComponentFixture<BootstraptestComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BootstraptestComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BootstraptestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InfovideopaneComponent } from './infovideopane.component';

describe('InfovideopaneComponent', () => {
  let component: InfovideopaneComponent;
  let fixture: ComponentFixture<InfovideopaneComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InfovideopaneComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InfovideopaneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

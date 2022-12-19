import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ControlFComponent } from './control-f.component';

describe('ControlFComponent', () => {
  let component: ControlFComponent;
  let fixture: ComponentFixture<ControlFComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ControlFComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ControlFComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

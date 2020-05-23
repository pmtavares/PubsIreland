import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PubEditComponent } from './pub-edit.component';

describe('PubEditComponent', () => {
  let component: PubEditComponent;
  let fixture: ComponentFixture<PubEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PubEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PubEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

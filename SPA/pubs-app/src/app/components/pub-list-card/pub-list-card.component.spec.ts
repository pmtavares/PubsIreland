import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PubListCardComponent } from './pub-list-card.component';

describe('PubsListCardComponent', () => {
  let component: PubListCardComponent;
  let fixture: ComponentFixture<PubListCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PubListCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PubListCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

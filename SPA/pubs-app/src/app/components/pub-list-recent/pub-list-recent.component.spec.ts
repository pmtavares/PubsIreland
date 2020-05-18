import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PubListRecentComponent } from './pub-list-recent.component';

describe('PubListRecentComponent', () => {
  let component: PubListRecentComponent;
  let fixture: ComponentFixture<PubListRecentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PubListRecentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PubListRecentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PubsSearchComponent } from './pubs-search.component';

describe('PubsSearchComponent', () => {
  let component: PubsSearchComponent;
  let fixture: ComponentFixture<PubsSearchComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PubsSearchComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PubsSearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

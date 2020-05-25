import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PubsSearchCityComponent } from './pubs-search-city.component';

describe('PubsSearchComponent', () => {
  let component: PubsSearchCityComponent;
  let fixture: ComponentFixture<PubsSearchCityComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PubsSearchCityComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PubsSearchCityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

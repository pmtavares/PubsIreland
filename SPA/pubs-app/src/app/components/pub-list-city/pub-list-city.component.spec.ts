import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PubListCityComponent } from './pub-list-city.component';

describe('PubListCityComponent', () => {
  let component: PubListCityComponent;
  let fixture: ComponentFixture<PubListCityComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PubListCityComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PubListCityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

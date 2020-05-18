import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PubsListCarouselComponent } from './pubs-list-carousel.component';

describe('PubsListCarouselComponent', () => {
  let component: PubsListCarouselComponent;
  let fixture: ComponentFixture<PubsListCarouselComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PubsListCarouselComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PubsListCarouselComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

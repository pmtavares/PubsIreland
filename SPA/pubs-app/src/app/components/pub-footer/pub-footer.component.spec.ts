import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PubFooterComponent } from './pub-footer.component';

describe('PubFooterComponent', () => {
  let component: PubFooterComponent;
  let fixture: ComponentFixture<PubFooterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PubFooterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PubFooterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

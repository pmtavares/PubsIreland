import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PubListResumeComponent } from './pub-list-resume.component';

describe('PubListResumeComponent', () => {
  let component: PubListResumeComponent;
  let fixture: ComponentFixture<PubListResumeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PubListResumeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PubListResumeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

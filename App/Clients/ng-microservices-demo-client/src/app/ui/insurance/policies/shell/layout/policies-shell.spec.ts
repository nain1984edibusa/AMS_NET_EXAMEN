import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PoliciesShell } from './policies-shell';

describe('PoliciesShell', () => {
  let component: PoliciesShell;
  let fixture: ComponentFixture<PoliciesShell>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PoliciesShell]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PoliciesShell);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

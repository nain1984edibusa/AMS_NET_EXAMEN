import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InsuranceShell } from './insurance-shell';

describe('InsuranceShell', () => {
  let component: InsuranceShell;
  let fixture: ComponentFixture<InsuranceShell>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InsuranceShell]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InsuranceShell);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

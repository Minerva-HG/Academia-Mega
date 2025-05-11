import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HijoServiceComponent } from './hijo-service.component';

describe('HijoServiceComponent', () => {
  let component: HijoServiceComponent;
  let fixture: ComponentFixture<HijoServiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HijoServiceComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HijoServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

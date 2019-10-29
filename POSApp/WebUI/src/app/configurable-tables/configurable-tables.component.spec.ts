import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfigurableTablesComponent } from './configurable-tables.component';

describe('ConfigurableTablesComponent', () => {
  let component: ConfigurableTablesComponent;
  let fixture: ComponentFixture<ConfigurableTablesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConfigurableTablesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfigurableTablesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

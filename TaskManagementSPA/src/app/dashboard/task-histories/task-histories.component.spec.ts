import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskHistoriesComponent } from './task-histories.component';

describe('TaskHistoriesComponent', () => {
  let component: TaskHistoriesComponent;
  let fixture: ComponentFixture<TaskHistoriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TaskHistoriesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TaskHistoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

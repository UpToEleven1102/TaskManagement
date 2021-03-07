import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskHistoriesListComponent } from './task-histories-list.component';

describe('TaskHistoriesListComponent', () => {
  let component: TaskHistoriesListComponent;
  let fixture: ComponentFixture<TaskHistoriesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TaskHistoriesListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TaskHistoriesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

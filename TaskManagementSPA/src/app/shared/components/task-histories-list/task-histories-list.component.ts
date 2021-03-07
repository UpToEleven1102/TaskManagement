import { Component, Input, OnInit } from '@angular/core';
import { TaskHistory } from '../../types';

@Component({
  selector: 'app-task-histories-list',
  templateUrl: './task-histories-list.component.html',
  styleUrls: ['./task-histories-list.component.css'],
})
export class TaskHistoriesListComponent implements OnInit {
  @Input() taskHistories!: TaskHistory[];
  constructor() {}

  ngOnInit(): void {}
}

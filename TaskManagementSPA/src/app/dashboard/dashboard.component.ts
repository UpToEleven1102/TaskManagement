import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  isMobile = false;
  constructor() { }

  ngOnInit(): void {
  }

  sizeChange(width: number): void {
    if (width < 790) {
      this.isMobile = true;
    }
  }
}

import { Component, HostListener, Output, EventEmitter, OnInit } from '@angular/core';

@Component({
  selector: 'app-size-detector',
  templateUrl: './size-detector.component.html',
  styleUrls: ['./size-detector.component.css'],
})
export class SizeDetectorComponent implements OnInit {
  @Output() innerWidth!: number;
  @Output() onSizeChange = new EventEmitter();

  @HostListener('window:resize', ['$event'])
  onResize(): void {
    this.innerWidth = window.innerWidth;
    this.onSizeChange.emit(window.innerWidth);
  }

  ngOnInit(): void {
    this.innerWidth = window.innerWidth;
    this.onSizeChange.emit(window.innerWidth);
  }
}

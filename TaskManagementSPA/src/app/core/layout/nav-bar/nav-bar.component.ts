import { Component, HostListener, Input, OnInit } from '@angular/core';
import { MenuService } from '../../services/menu.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css'],
})
export class NavBarComponent implements OnInit {
  @Input() isMobile = false;
  innerTop = 0;
  constructor(public menuService: MenuService) {}

  @HostListener('window:scroll', ['$event'])
  onResize(): void {
    this.innerTop = window.pageYOffset;
  }
  ngOnInit(): void {}
}

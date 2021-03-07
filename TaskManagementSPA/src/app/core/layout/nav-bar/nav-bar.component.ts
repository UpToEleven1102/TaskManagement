import {Component, Input, OnInit} from '@angular/core';
import {MenuService} from '../../services/menu.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  @Input() isMobile = false;
  constructor(public menuService: MenuService) { }

  ngOnInit(): void {
  }

}

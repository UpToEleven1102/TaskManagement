import {Component, Input, OnInit} from '@angular/core';
import { MenuService } from '../../services/menu.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css'],
})
export class MenuComponent implements OnInit {
  @Input() isMobile = false;
  constructor(public menuService: MenuService) {}

  ngOnInit(): void {}
}

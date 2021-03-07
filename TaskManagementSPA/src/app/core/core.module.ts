import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './layout/nav-bar/nav-bar.component';
import { MenuComponent } from './layout/menu/menu.component';
import { NgbCollapseModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterModule } from '@angular/router';
import { PhonePipe } from './pipes/phone.pipe';

@NgModule({
  declarations: [NavBarComponent, MenuComponent, PhonePipe],
  exports: [NavBarComponent, MenuComponent, PhonePipe],
  imports: [CommonModule, NgbCollapseModule, RouterModule],
})
export class CoreModule {}

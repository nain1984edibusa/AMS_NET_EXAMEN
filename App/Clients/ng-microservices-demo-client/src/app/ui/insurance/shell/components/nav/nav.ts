import { Component } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-nav',
  imports: [
    MatIconModule,
    MatMenuModule,
    MatListModule,    
    RouterLink,
    RouterLinkActive
  ],
  templateUrl: './nav.html',
  styleUrl: './nav.scss'
})
export class Nav {
  public navItems = [
    { link: 'policies', label: 'Policies', icon: 'security' },
    { link: 'payments', label: 'Payments', icon: 'payments' },
    { link: 'reports', label: 'Reports', icon: 'table_view' }
  ];
}

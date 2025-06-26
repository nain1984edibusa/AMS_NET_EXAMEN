import { AsyncPipe } from '@angular/common';
import { Component, inject, Input, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatSidenav } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { Observable } from 'rxjs';
import { CapitalizePipe } from '../../../../shared/pipes/capitalize-pipe';
import { AuthService } from '../../../../../infrastructure/security/auth.service';
import { OAuthService } from 'angular-oauth2-oidc';

@Component({
  selector: 'app-header',
  imports: [
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatMenuModule,
    AsyncPipe,
    CapitalizePipe
  ],
  templateUrl: './header.html',
  styleUrl: './header.scss'
})
export class Header implements OnInit {
  @Input() isHandset$!: Observable<boolean>;
  @Input() drawer!: MatSidenav;

  private oauthService = inject(OAuthService);
  public claims: any;
  readonly isLoggedIn = inject(AuthService).isLoggedIn;

  public ngOnInit(): void {
    this.claims = this.oauthService.getIdentityClaims();    
  }

  logout(): void {
    this.oauthService.logOut();
  }

  login(): void {
    this.oauthService.initLoginFlow();
  }
}

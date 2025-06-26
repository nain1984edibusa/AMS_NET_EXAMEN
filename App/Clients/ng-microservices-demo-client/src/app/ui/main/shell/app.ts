import { Component, inject, OnInit } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { OAuthService } from 'angular-oauth2-oidc';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App implements OnInit {
  protected title = 'Insurance Sales Portal';

  private oauth = inject(OAuthService);
  private router = inject(Router);

  ngOnInit(): void {
    this.oauth.loadDiscoveryDocumentAndTryLogin().then(() => {
      if (this.oauth.hasValidAccessToken()) {
        console.log('🟢 Token received:', this.oauth.getAccessToken());

        const target = this.oauth.state ? decodeURIComponent(this.oauth.state) : '/';
        this.router.navigateByUrl(target, { replaceUrl: true });

        this.router.navigateByUrl(target, { replaceUrl: true });
      } else {
        console.warn('🔴 No valid token yet.');
      }
      }).catch((error) => {
      console.error('🔴 OIDC error:', error);
    });
  }
}

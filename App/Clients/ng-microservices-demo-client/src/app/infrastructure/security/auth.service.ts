import { Injectable, signal } from "@angular/core";
import { ConfigService } from "../config/config-service";
import { AuthConfig, OAuthErrorEvent, OAuthEvent, OAuthService } from "angular-oauth2-oidc";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  readonly isLoggedIn = signal(false);

  constructor(
    private configService: ConfigService,
    private oauth: OAuthService
  ) {
    this.isLoggedIn.set(this.oauth.hasValidAccessToken());
    this.oauth.events.subscribe((event: OAuthEvent) => {
      if (
        event.type === 'token_received' ||
        event.type === 'token_refreshed' ||
        event.type === 'logout' ||
        event instanceof OAuthErrorEvent
      ) {
        this.isLoggedIn.set(this.oauth.hasValidAccessToken());
      }
    });
  }

  init(): Promise<any> {
    return this.configService.getConfig().then(() => {

      const idp = this.configService.getValue('IDP') || {};
      console.log(idp);
      const authConfig: AuthConfig = {
        issuer: idp.ISSUER,
        clientId: idp.CLIENT_ID,
        redirectUri: idp.REDIRECT_URI,
        postLogoutRedirectUri: idp.POST_LOGOUT_REDIRECT_URI,
        responseType: idp.RESPONSE_TYPE || 'code',
        scope: idp.SCOPE || 'openid profile email',
        strictDiscoveryDocumentValidation: idp.STRICT_DISCOVERY_DOCUMENT_VALIDATION ?? true,
        showDebugInformation: idp.SHOW_DEBUG_INFORMATION ?? false
      };

      this.oauth.configure(authConfig);
      return this.oauth.loadDiscoveryDocument();
    });
  }
}

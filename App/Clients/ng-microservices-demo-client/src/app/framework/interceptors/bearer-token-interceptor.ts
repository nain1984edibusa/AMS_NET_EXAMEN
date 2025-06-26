import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { ConfigService } from '../../infrastructure/config/config-service';
import { OAuthService } from 'angular-oauth2-oidc';


export const bearerTokenInterceptor: HttpInterceptorFn = (req, next) => {
  const configService = inject(ConfigService);
  const oauthService = inject(OAuthService);

  const gatewayUrl = configService.getValue('GATEWAY_URL')?.replace(/\/$/, '');
  const pattern = gatewayUrl
    ? new RegExp(`^${gatewayUrl.replace(/[.*+?^${}()|[\]\\]/g, '\\$&')}(\\/.*)?$`, 'i')
    : null;

  if (pattern && pattern.test(req.url)) {
    const token = oauthService.getAccessToken();
    if (token) {
      const cloned = req.clone({
        setHeaders: { Authorization: `Bearer ${token}` }
      });
      return next(cloned);
    }
  }
  return next(req);
};

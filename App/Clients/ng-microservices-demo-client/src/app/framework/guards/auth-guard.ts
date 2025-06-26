import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { OAuthService } from 'angular-oauth2-oidc';

export const authGuard: CanActivateFn = (route, state) => {
  const oauthService = inject(OAuthService);
  const router = inject(Router);
    
  if (!oauthService.hasValidAccessToken()) {
    oauthService.initLoginFlow(state.url);
    return false;
  }

  //const requiredRole = route.data['role'];
  //if (!requiredRole) {
  //  return router.parseUrl('/forbidden');
  //}

  //const claims: any = oauthService.getIdentityClaims();
  //const roles = claims?.roles

  //const hasRequiredRole = roles.includes(requiredRole);

  //if (!hasRequiredRole) {
  //  return router.parseUrl('/forbidden');
  //}

  return true;
};

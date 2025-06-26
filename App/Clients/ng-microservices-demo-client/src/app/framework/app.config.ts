import { ApplicationConfig, provideBrowserGlobalErrorListeners, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';
import { APP_ROUTES } from '../ui/main/routes/app.routes';
import { provideOAuthClient } from 'angular-oauth2-oidc';
import { provideConfig } from './providers/config-provider';
import { provideAuth } from './providers/auth-provider';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { bearerTokenInterceptor } from './interceptors/bearer-token-interceptor';
import { provideRepositories } from './providers/repositories.provider';
import { provideDate } from './providers/date-provider';

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideOAuthClient(),
    provideConfig(),
    provideAuth(),
    provideRouter(APP_ROUTES),
    provideHttpClient(withInterceptors([bearerTokenInterceptor])),
    provideDate(),
    provideRepositories()
  ]
};

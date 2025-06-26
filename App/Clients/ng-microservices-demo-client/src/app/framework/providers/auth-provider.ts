import { APP_INITIALIZER, Provider } from "@angular/core";
import { AuthService } from "../../infrastructure/security/auth.service";
import { ConfigService } from "../../infrastructure/config/config-service";

export function initializeAuth(authInit: AuthService): () => Promise<any> {
  return () => authInit.init();
}

export function provideAuth(): Provider {
  return {
    provide: APP_INITIALIZER,
    useFactory: initializeAuth,
    deps: [AuthService, ConfigService],
    multi: true
  };
}

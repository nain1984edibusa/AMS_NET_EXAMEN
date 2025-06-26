import { APP_INITIALIZER, Provider } from "@angular/core";
import { ConfigService } from "../../infrastructure/config/config-service";

export function initializeConfig(configService: ConfigService): () => Promise<any> {
  return (): Promise<any> => {
    return configService.getConfig()
      .then((config) => {
        if (!config) {
          console.error("Error to load configuration");
          return Promise.resolve(true);
        }
        return Promise.resolve(true);
      })
      .catch((error) => {
        console.error("Error to load configuration", error);
        return Promise.reject(new Error("Error to load configuration"));
      });
  };
}

export function provideConfig(): Provider {
  return {
    provide: APP_INITIALIZER,
    useFactory: initializeConfig,
    deps: [ConfigService],
    multi: true
  };
}

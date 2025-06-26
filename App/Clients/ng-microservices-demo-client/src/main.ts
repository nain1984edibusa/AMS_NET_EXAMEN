import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/framework/app.config';
import { App } from './app/ui/main/shell/app';

bootstrapApplication(App, appConfig)
  .catch((err) => console.error(err));

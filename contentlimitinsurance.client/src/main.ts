import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';

export function getBaseUrl() {
  let baseUrl = document.getElementsByTagName('base')[0].href.slice(0, -1);
  return baseUrl.replace(/^http[s]{0,1}\:/, '');
}


platformBrowserDynamic().bootstrapModule(AppModule, {
    ngZoneEventCoalescing: true
  })
  .catch(err => console.error(err));

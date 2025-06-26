import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { catchError, firstValueFrom, mergeMap, of } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {
  private config: any;
  private STORAGE_KEY = 'appConfig';
  private http = inject(HttpClient);

  public async getConfig(): Promise<any> {
    return await firstValueFrom(this.http
      .get(this.getConfigFile(), { observe: 'response' })
      .pipe(
        catchError((error) => {
          console.log(error);
          return of(null);
        }),
        mergeMap((response) => {
          this.config = response?.body;
          this.setConfigToStorage(this.config);
          return of(this.config);
        })
      ));
  }

  public getValue(key: string): any {
    let result = this.config;
    if (!result) {
      result = this.getConfigFromStorage();
    }
    if (!result) {
      return null;
    }

    const keys = key.split('.');
    for (const k of keys) {
      if (result && result[k] !== undefined) {
        result = result[k];
      } else {
        return null;
      }
    }
    return result;
  }

  private getConfigFromStorage(): any {
    const storedConfig = sessionStorage.getItem(this.STORAGE_KEY);

    if (!storedConfig || storedConfig === 'undefined') {
      return null;
    }
    try {
      return JSON.parse(storedConfig);
    } catch (err) {
      sessionStorage.removeItem(this.STORAGE_KEY);
      return null;
    }
  }

  private setConfigToStorage(config: any): void {
    if (!config) {
      return;
    }
    sessionStorage.setItem(this.STORAGE_KEY, JSON.stringify(config));
  }

  private getConfigFile(): string {
    return environment.configFile;
  }
}


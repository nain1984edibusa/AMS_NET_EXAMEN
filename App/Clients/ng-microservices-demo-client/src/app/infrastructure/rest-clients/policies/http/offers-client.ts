import { inject, Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { catchError, firstValueFrom, throwError } from "rxjs";
import { ConfigService } from "../../../config/config-service";
import { CalculatePriceRequest } from "../models/requests/calculate-price-request";
import { CalculatePriceResponse } from "../models/responses/calculate-price-response";

@Injectable({
  providedIn: 'root'
})
export class OffersClient {
  private configService = inject(ConfigService);
  private http = inject(HttpClient);
  private offersUrl = '';

  constructor() {
    this.offersUrl = `${this.configService.getValue('OFFERS_URL')}`;
  }

  public async calculatePrice(request: CalculatePriceRequest): Promise<CalculatePriceResponse> {
    return await firstValueFrom(this.http.post<CalculatePriceResponse>(this.offersUrl, request).pipe(catchError(this.handleError)));
  }

  private handleError(error: HttpErrorResponse) {
    console.error('server error:', error);
    if (error.error instanceof Error) {
      const errMessage = error.error.message;
      return throwError(() => errMessage);
    }
    return throwError(() => error || 'Server error');
  }
}

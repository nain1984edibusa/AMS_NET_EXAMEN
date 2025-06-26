import { inject, Injectable } from "@angular/core";
import { ConfigService } from "../../../config/config-service";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { GetProductByCodeResponse } from "../models/response/get-product-by-code-response";
import { catchError, firstValueFrom, throwError } from "rxjs";
import { GetAllProductsResponse } from "../models/response/get-all-products-response";

@Injectable({
  providedIn: 'root'
})
export class ProductsClient {
  private configService = inject(ConfigService);
  private http = inject(HttpClient);
  private productsUrl = '';

  constructor() {
    this.productsUrl = `${this.configService.getValue('PRODUCTS_URL')}`;
  }

  public async getAllProducts(): Promise<GetAllProductsResponse> {
    return await firstValueFrom(this.http.get<GetAllProductsResponse>(this.productsUrl).pipe(catchError(this.handleError)));
  }

  public async getProductByCode(code: string): Promise<GetProductByCodeResponse> {
    return await firstValueFrom(this.http.get<GetProductByCodeResponse>(`${this.productsUrl}/${code}`).pipe(catchError(this.handleError)));
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

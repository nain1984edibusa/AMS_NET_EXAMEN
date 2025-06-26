import { inject, Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { catchError, firstValueFrom, throwError } from "rxjs";
import { ConfigService } from "../../../config/config-service";
import { CreatePolicyRequest } from "../models/requests/create-policy-request";
import { CreatePolicyResponse } from "../models/responses/create-policy-response";

@Injectable({
  providedIn: 'root'
})
export class PoliciesClient {
  private configService = inject(ConfigService);
  private http = inject(HttpClient);
  private policiesUrl = '';

  constructor() {
    this.policiesUrl = `${this.configService.getValue('POLICIES_URL')}`;
  }

  public async createPolicy(request: CreatePolicyRequest): Promise<CreatePolicyResponse> {
    return await firstValueFrom(this.http.post<CreatePolicyResponse>(this.policiesUrl, request).pipe(catchError(this.handleError)));
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

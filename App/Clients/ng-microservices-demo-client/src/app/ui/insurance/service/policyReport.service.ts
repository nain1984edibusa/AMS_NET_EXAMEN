import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { ConfigService } from '../../../infrastructure/config/config-service';
import { Observable } from 'rxjs';
import { PolicyReport } from '../interfaces/policyReport.interface';

@Injectable({
  providedIn: 'root'
})
export class PolicyReportService {
  
  // private endpoint: string ;

  // constructor(private httpClient: HttpClient) {
  //   this.endpoint = env.endPoint
  // }


  // listaBeneficioTributario(): Observable<any> {
  //   return this.httpClient
  //     .get(`${this.endpoint}/api/report`)
  //     .pipe((res) => res);
  // }

  private configService = inject(ConfigService);
  private http = inject(HttpClient);
  private reportsUrl = '';

  constructor() {
    this.reportsUrl = 'http://localhost:8990/gateway/reports';
  }

  // consultarPolicies(): Observable<any> {
  //   debugger
  //   return this.http
  //     .get(this.productsUrl)
  //     .pipe((res) => res);
  // }

  consultarPolicies(): Observable<PolicyReport[]> {
    debugger
    return this.http.get<PolicyReport[]>(this.reportsUrl);
  }

}


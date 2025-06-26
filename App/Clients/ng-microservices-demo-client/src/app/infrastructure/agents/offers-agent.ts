import { inject, Injectable } from '@angular/core';
import { OffersClient } from '../rest-clients/policies/http/offers-client';
import { offersAgentMapper } from './mappings/offers-agent-mapper';
import { CalculatePriceRequest } from '../rest-clients/policies/models/requests/calculate-price-request';
import { CalculatePriceResponse } from '../rest-clients/policies/models/responses/calculate-price-response';
import { CalculatePriceParamsModel } from '../../application/policies/offer/models/calculate-price-params-model';
import { CalculatedPrice } from '../../domain/policies/value-objects/calculated-price';

@Injectable({
  providedIn: 'root'
})
export class OffersAgent {
  private offersClient = inject(OffersClient);
  constructor() { }

  public async calculatePrice(params: CalculatePriceParamsModel): Promise<CalculatedPrice> {    
    const request = offersAgentMapper.map(params, CalculatePriceParamsModel, CalculatePriceRequest);
    const response = await this.offersClient.calculatePrice(request);
    const calculatedPrice = offersAgentMapper.map(response, CalculatePriceResponse, CalculatedPrice);

    return calculatedPrice;
  }  
}

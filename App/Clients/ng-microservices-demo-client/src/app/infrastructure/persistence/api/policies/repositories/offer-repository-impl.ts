import { inject, Injectable } from "@angular/core";
import { OfferRepository } from "../../../../../domain/policies/interfaces/offer-repository";
import { OffersAgent } from "../../../../agents/offers-agent";
import { CalculatePriceParamsModel } from "../../../../../application/policies/offer/models/calculate-price-params-model";
import { CalculatedPrice } from "../../../../../domain/policies/value-objects/calculated-price";

@Injectable({
  providedIn: 'root'
})
export class OfferRepositoryImpl implements OfferRepository {
  private offersAgent = inject(OffersAgent);  

  public async calculatePrice(params: CalculatePriceParamsModel): Promise<CalculatedPrice> {    
    const calculatedPrice = await this.offersAgent.calculatePrice(params);
    return calculatedPrice;
  }  
}


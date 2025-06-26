import { InjectionToken } from "@angular/core";
import { Offer } from "../entities/offer";
import { CalculatePriceParamsModel } from "../../../application/policies/offer/models/calculate-price-params-model";
import { CalculatedPrice } from "../value-objects/calculated-price";

export const OFFER_REPOSITORY_TOKEN = new InjectionToken<OfferRepository>('OfferRepository');
export interface OfferRepository {
  calculatePrice(params: CalculatePriceParamsModel): Promise<CalculatedPrice>;  
}

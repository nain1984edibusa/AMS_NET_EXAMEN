import { inject, Injectable } from "@angular/core";
import { CalculatePriceCommand } from "./calculate-price-command";
import { PolicyUnitOfWork } from "../../../../../../infrastructure/persistence/api/policies/repositories/policy-unit-of-work";
import { offerMapper } from "../../../mappings/offer-mapper";
import { OfferModel } from "../../../models/offer-model";
import { CalculatePriceParamsModel } from "../../../models/calculate-price-params-model";
import { CalculatedPrice } from "../../../../../../domain/policies/value-objects/calculated-price";

@Injectable({
  providedIn: 'root'
})
export class CalculatePriceUseCase {
  private unitOfWork = inject(PolicyUnitOfWork);

  public async execute(input: CalculatePriceCommand): Promise<OfferModel> {    
    const param = offerMapper.map(input, CalculatePriceCommand, CalculatePriceParamsModel);
    const calculatedPrice = await this.unitOfWork.offerRepository.calculatePrice(param);
    const result = offerMapper.map(calculatedPrice, CalculatedPrice, OfferModel);

    return result;
  }
}

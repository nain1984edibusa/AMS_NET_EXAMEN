import { inject, Injectable } from "@angular/core";
import { CalculatePriceUseCase } from "../use-cases/commands/calculate-price/calculate-price-use-case";

@Injectable({
  providedIn: 'root'
})
export class OfferApplicationService {
  public calculatePrice = inject(CalculatePriceUseCase);

}

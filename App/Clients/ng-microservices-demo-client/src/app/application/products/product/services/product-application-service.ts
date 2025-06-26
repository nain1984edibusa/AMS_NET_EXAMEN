import { inject, Injectable } from "@angular/core";
import { GetAllProductsUseCase } from "../use-cases/queries/get-all-products/get-all-products-use-case";

@Injectable({
  providedIn: 'root'
})
export class ProductApplicationService {
  public getAllProducts = inject(GetAllProductsUseCase);

}

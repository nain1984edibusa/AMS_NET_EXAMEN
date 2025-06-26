import { inject, Injectable } from "@angular/core";
import { PRODUCT_REPOSITORY_TOKEN } from "../../../../../domain/products/interfaces/product-repository";

@Injectable({
  providedIn: 'root'
})
export class ProductUnitOfWork {
  public productRepository = inject(PRODUCT_REPOSITORY_TOKEN);
}

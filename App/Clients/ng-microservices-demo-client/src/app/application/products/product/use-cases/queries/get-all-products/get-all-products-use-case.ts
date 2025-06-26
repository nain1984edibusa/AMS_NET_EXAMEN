import { inject, Injectable } from "@angular/core";
import { ProductUnitOfWork } from "../../../../../../infrastructure/persistence/api/products/repositories/product-unit-of-work";
import { productMapper } from "../../../mappings/product-mapper";
import { Product } from "../../../../../../domain/products/entities/product";
import { ProductModel } from "../../../models/products-model";

@Injectable({
  providedIn: 'root'
})
export class GetAllProductsUseCase {
  private unitOfWork = inject(ProductUnitOfWork);

  public async execute(): Promise<Array<ProductModel>> {
    const products = await this.unitOfWork.productRepository.getAllProducts();
    const result = productMapper.mapArray(products, Product, ProductModel);
    
    return result;
  }
}

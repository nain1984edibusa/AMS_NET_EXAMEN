import { InjectionToken } from "@angular/core";
import { Product } from "../entities/product";

export const PRODUCT_REPOSITORY_TOKEN = new InjectionToken<ProductsRepository>('ProductsRepository');
export interface ProductsRepository {
  getAllProducts(): Promise<Array<Product>>;
  getProductByCode(code: string): Promise<Product>;
}

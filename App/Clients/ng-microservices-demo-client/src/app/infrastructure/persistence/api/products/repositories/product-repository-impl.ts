import { inject, Injectable } from "@angular/core";
import { ProductsAgent } from "../../../../agents/products-agent";
import { ProductsRepository } from "../../../../../domain/products/interfaces/product-repository";
import { Product } from "../../../../../domain/products/entities/product";
import { productsAgentMapper } from "../../../../agents/mappings/products-agent-mapper";
import { ProductResponse } from "../../../../rest-clients/products/models/response/products-response";

@Injectable({
  providedIn: 'root'
})
export class ProductRepositoryImpl implements ProductsRepository {
  private productsAgent = inject(ProductsAgent);  

  public async getAllProducts(): Promise<Array<Product>> {    
    const products = await this.productsAgent.getAllProducts();
    return products;
  }

  public async getProductByCode(code: string): Promise<Product> {
    const product = await this.productsAgent.getProductByCode(code);
    return product;
  }  
}

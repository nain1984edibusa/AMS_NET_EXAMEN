import { inject, Injectable } from '@angular/core';
import { ProductsClient } from '../../infrastructure/rest-clients/products/http/products-client';
import { Product } from '../../domain/products/entities/product';
import { productsAgentMapper } from './mappings/products-agent-mapper';
import { ProductResponse } from '../rest-clients/products/models/response/products-response';

@Injectable({
  providedIn: 'root'
})
export class ProductsAgent {
  private productsClient = inject(ProductsClient);
  constructor() { }

  public async getAllProducts(): Promise<Product[]> {
    const response = await this.productsClient.getAllProducts();
    const products = productsAgentMapper.mapArray(response.products, ProductResponse, Product);

    return products;
  }
  public async getProductByCode(code: string): Promise<Product> {
    const response = await this.productsClient.getProductByCode(code);
    const product = productsAgentMapper.map(response, ProductResponse, Product);

    return product;
  }
}

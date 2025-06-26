import { ProductResponse } from "./products-response";
export class GetAllProductsResponse {
  constructor(
    public products: Array<ProductResponse> = [],    
  ) {}
}

import { Provider } from "@angular/core";
import { PRODUCT_REPOSITORY_TOKEN } from "../../domain/products/interfaces/product-repository";
import { ProductRepositoryImpl } from "../../infrastructure/persistence/api/products/repositories/product-repository-impl";
import { OFFER_REPOSITORY_TOKEN } from "../../domain/policies/interfaces/offer-repository";
import { OfferRepositoryImpl } from "../../infrastructure/persistence/api/policies/repositories/offer-repository-impl";
import { POLICY_REPOSITORY_TOKEN } from "../../domain/policies/interfaces/policy-repository";
import { PolicyRepositoryImpl } from "../../infrastructure/persistence/api/policies/repositories/policy-repository-impl";

export function provideRepositories(): Provider[] {
  return [
    { provide: PRODUCT_REPOSITORY_TOKEN, useClass: ProductRepositoryImpl },
    { provide: OFFER_REPOSITORY_TOKEN, useClass: OfferRepositoryImpl },
    { provide: POLICY_REPOSITORY_TOKEN, useClass: PolicyRepositoryImpl },
    // Agrega otros repositorios aquí
  ];
}

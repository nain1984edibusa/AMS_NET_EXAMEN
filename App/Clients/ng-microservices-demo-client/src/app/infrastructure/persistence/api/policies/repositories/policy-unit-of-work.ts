import { inject, Injectable } from "@angular/core";
import { OFFER_REPOSITORY_TOKEN } from "../../../../../domain/policies/interfaces/offer-repository";
import { POLICY_REPOSITORY_TOKEN } from "../../../../../domain/policies/interfaces/policy-repository";

@Injectable({
  providedIn: 'root'
})
export class PolicyUnitOfWork {
  public offerRepository = inject(OFFER_REPOSITORY_TOKEN);
  public policyRepository = inject(POLICY_REPOSITORY_TOKEN);
}

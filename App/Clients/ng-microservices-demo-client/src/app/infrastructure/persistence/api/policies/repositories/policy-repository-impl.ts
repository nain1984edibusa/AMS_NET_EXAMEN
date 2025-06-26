import { inject, Injectable } from "@angular/core";
import { PolicyRepository } from "../../../../../domain/policies/interfaces/policy-repository";
import { PoliciesAgent } from "../../../../agents/policies-agent";
import { Policy } from "../../../../../domain/policies/entities/policy";

@Injectable({
  providedIn: 'root'
})
export class PolicyRepositoryImpl implements PolicyRepository {
  private policiesAgent = inject(PoliciesAgent);  

  public async createPolicy(policy: Policy): Promise<Policy> {
    const newPolicy = await this.policiesAgent.createPolicy(policy);
    return newPolicy;
  }  
}


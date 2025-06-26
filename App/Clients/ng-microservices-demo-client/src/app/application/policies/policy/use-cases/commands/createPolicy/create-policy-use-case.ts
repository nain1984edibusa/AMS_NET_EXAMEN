import { inject, Injectable } from "@angular/core";
import { PolicyUnitOfWork } from "../../../../../../infrastructure/persistence/api/policies/repositories/policy-unit-of-work";
import { CreatePolicyCommand } from "./create-policy-command";
import { PolicyModel } from "../../../models/policy-model";
import { policyMapper } from "../../../mappings/policy-mapper";
import { Policy } from "../../../../../../domain/policies/entities/policy";

@Injectable({
  providedIn: 'root'
})
export class CreatePolicyUseCase {
  private unitOfWork = inject(PolicyUnitOfWork);

  public async execute(input: CreatePolicyCommand): Promise<PolicyModel> {    
    const policy = policyMapper.map(input, CreatePolicyCommand, Policy);
    const createdPolicy = await this.unitOfWork.policyRepository.createPolicy(policy);
    const result = policyMapper.map(createdPolicy, Policy, PolicyModel);

    return result;
  }
}

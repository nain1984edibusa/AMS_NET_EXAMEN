import { InjectionToken } from "@angular/core";
import { Policy } from "../entities/policy";

export const POLICY_REPOSITORY_TOKEN = new InjectionToken<PolicyRepository>('PolicyRepository');
export interface PolicyRepository {
  createPolicy(policy: Policy): Promise<Policy>;  
}

import { inject, Injectable } from '@angular/core';
import { PoliciesClient } from '../rest-clients/policies/http/policies-client';
import { Policy } from '../../domain/policies/entities/policy';
import { policiesAgentMapper } from './mappings/policies-agent-mapper';
import { CreatePolicyRequest } from '../rest-clients/policies/models/requests/create-policy-request';
import { CreatePolicyResponse } from '../rest-clients/policies/models/responses/create-policy-response';

@Injectable({
  providedIn: 'root'
})
export class PoliciesAgent {
  private policiesClient = inject(PoliciesClient);
  constructor() { }

  public async createPolicy(policy: Policy): Promise<Policy> {    
    const request = policiesAgentMapper.map(policy, Policy, CreatePolicyRequest);
    const response = await this.policiesClient.createPolicy(request);
    const createdPolicy = policiesAgentMapper.map(response, CreatePolicyResponse, Policy);

    return createdPolicy;
  }  
}

import { classes } from '@automapper/classes';
import { createMap, createMapper, forMember, mapFrom, Mapper } from '@automapper/core';
import { Policy } from '../../../domain/policies/entities/policy';
import { CreatePolicyRequest } from '../../rest-clients/policies/models/requests/create-policy-request';
import { CreatePolicyResponse } from '../../rest-clients/policies/models/responses/create-policy-response';
import { Cover } from '../../../domain/policies/value-objects/cover';
import { PolicyHolder } from '../../../domain/policies/value-objects/policy-holder';
import { PersonDto } from '../../rest-clients/policies/models/dtos/person-dto';

export const policiesAgentMapper: Mapper = createMapper({
  strategyInitializer: classes(),
});

createMap(policiesAgentMapper, Policy, CreatePolicyRequest,
  forMember(dest => dest.policyHolderAddress, mapFrom(src => src.policyHolder.address)),  
);

createMap(policiesAgentMapper, PolicyHolder, PersonDto,
  forMember(dest => dest.taxId, mapFrom(src => src.pesel)),
)

createMap(policiesAgentMapper, CreatePolicyResponse, Policy,
  forMember(dest => dest.holder, mapFrom(src => src.policyHolder)),
    forMember(dest => dest.covers, mapFrom(src => src.covers.map(cover=>new Cover(cover,0))))
)



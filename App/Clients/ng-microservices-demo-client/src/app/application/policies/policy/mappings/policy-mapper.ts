import { classes } from "@automapper/classes";
import { createMap, createMapper, forMember, mapFrom, Mapper } from "@automapper/core";
import { CreatePolicyCommand } from "../use-cases/commands/createPolicy/create-policy-command";
import { Policy } from "../../../../domain/policies/entities/policy";
import { PolicyHolder } from "../../../../domain/policies/value-objects/policy-holder";
import { PolicyModel } from "../models/policy-model";
import { PersonModel } from "../models/person-model";

export const policyMapper: Mapper = createMapper({
  strategyInitializer: classes(),
});

createMap(policyMapper, CreatePolicyCommand, Policy,  
  forMember(dest => dest.policyHolder.address, mapFrom(src => src.policyHolderAddress))
)

createMap(policyMapper, PersonModel, PolicyHolder,
  forMember(dest => dest.pesel, mapFrom(src => src.taxId))
  );


createMap(policyMapper, Policy, PolicyModel,
  forMember(dest => dest.covers, mapFrom(src => src.covers.map(cover => cover.code)))  
);




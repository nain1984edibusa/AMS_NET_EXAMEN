import { AutoMap } from "@automapper/classes";
import { PersonDto } from "../dtos/person-dto";
import { AddressDto } from "../dtos/adress-dto";
export class CreatePolicyRequest {
  @AutoMap()
  public offerNumber: string;
  @AutoMap()
  public policyHolder: PersonDto;
  @AutoMap()
  public policyHolderAddress: AddressDto;

  constructor(
    offerNumber: string = '',
    policyHolder: PersonDto = new PersonDto(),
    policyHolderAddress: AddressDto = new AddressDto()
  ) {
    this.offerNumber = offerNumber;
    this.policyHolder = policyHolder;
    this.policyHolderAddress = policyHolderAddress;
  }
}

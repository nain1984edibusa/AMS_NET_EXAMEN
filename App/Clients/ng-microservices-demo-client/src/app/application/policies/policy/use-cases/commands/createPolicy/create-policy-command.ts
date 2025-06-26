import { AutoMap } from '@automapper/classes';
import { PersonModel } from '../../../models/person-model';
import { AddressModel } from '../../../models/adress-model';
export class CreatePolicyCommand {
  @AutoMap()
  public offerNumber: string;
  @AutoMap()
  public policyHolder: PersonModel;
  @AutoMap()
  public policyHolderAddress: AddressModel;

  constructor(
    offerNumber: string = '',
    policyHolder: PersonModel = new PersonModel(),
    policyHolderAddress: AddressModel = new AddressModel()
  ) {
    this.offerNumber = offerNumber;
    this.policyHolder = policyHolder;
    this.policyHolderAddress = policyHolderAddress;
  }
}

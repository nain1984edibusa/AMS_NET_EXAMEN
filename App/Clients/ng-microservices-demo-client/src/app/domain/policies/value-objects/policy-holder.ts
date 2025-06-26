import { AutoMap } from '@automapper/classes';
import { Address } from './address';

export class PolicyHolder {
  @AutoMap()
  public firstName: string;
  @AutoMap()
  public lastName: string;
  @AutoMap()
  public pesel: string;
  @AutoMap()
  public address: Address;
  constructor(
    firstName: string,
    lastName: string,
    pesel: string,
    address: Address
  ) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.pesel = pesel;
    this.address = address;
  }
}

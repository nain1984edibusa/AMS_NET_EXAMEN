import { AutoMap } from "@automapper/classes";
export class PersonDto {
  @AutoMap()
  public firstName: string;
  @AutoMap()
  public lastName: string;
  @AutoMap()
  public taxId: string;

  constructor(firstName: string = '', lastName: string = '', taxId: string = '') {
    this.firstName = firstName;
    this.lastName = lastName;
    this.taxId = taxId;
  }
}

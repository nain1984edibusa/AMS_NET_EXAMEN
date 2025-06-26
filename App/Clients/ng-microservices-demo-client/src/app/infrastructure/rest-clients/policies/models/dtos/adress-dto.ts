import { AutoMap } from "@automapper/classes";

export class AddressDto {
  @AutoMap()
  public country: string;
  @AutoMap()
  public zipCode: string;
  @AutoMap()
  public city: string;
  @AutoMap()
  public street: string;

  constructor(
    country: string = '',
    zipCode: string = '',
    city: string = '',
    street: string = ''
  ) {
    this.country = country;
    this.zipCode = zipCode;
    this.city = city;
    this.street = street;
  }
}

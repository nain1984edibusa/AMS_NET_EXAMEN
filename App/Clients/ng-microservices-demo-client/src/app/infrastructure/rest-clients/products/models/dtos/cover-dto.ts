import { AutoMap } from "@automapper/classes";

export class CoverDto {
  @AutoMap()
  public code: string;

  @AutoMap()
  public name: string;

  @AutoMap()
  public description: string;

  @AutoMap()
  public optional: boolean;

  @AutoMap()
  public sumInsured: number;

  constructor(
    code: string,
    name: string,
    description: string,
    optional: boolean,
    sumInsured: number
  ) {
    this.code = code;
    this.name = name;
    this.description = description;
    this.optional = optional;
    this.sumInsured = sumInsured;
  }
}

import { AutoMap } from "@automapper/classes"

export class ChoiceModel {
  @AutoMap()
  public code: string;
  @AutoMap()
  public label: string
  constructor(
    code: string,
    label: string
  ) {
    this.code = code;
    this.label = label;
  }
}

import { AutoMap } from "@automapper/classes"
import { AnswerModel } from "./answer-model";
export class CalculatePriceParamsModel {
  @AutoMap()
  public productCode: string;

  @AutoMap()
  public policyFrom: Date;

  @AutoMap()
  public policyTo: Date;

  @AutoMap()
  public selectedCovers: string[];

  @AutoMap()
  public answers: AnswerModel[];

  constructor(
    productCode: string,
    policyFrom: Date,
    policyTo: Date,
    selectedCovers: string[],
    answers: AnswerModel[]
  ) {
    this.productCode = productCode;
    this.policyFrom = policyFrom;
    this.policyTo = policyTo;
    this.selectedCovers = selectedCovers;
    this.answers = answers;
  }
}

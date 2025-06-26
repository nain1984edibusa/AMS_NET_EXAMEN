import { AutoMap } from "@automapper/classes";
import { QuestionAnswerDto } from "../dtos/question-answer-dto";

export class CalculatePriceRequest {
  @AutoMap()
  public productCode: string;
  @AutoMap()
  public policyFrom: Date;
  @AutoMap()
  public policyTo: Date;
  @AutoMap()
  public selectedCovers: string[];
  @AutoMap()
  public answers?: QuestionAnswerDto[];

  constructor(
    productCode: string = '',
    policyFrom: Date = new Date(),
    policyTo: Date = new Date(),
    selectedCovers: string[] = []
  ) {
    this.productCode = productCode;
    this.policyFrom = policyFrom;
    this.policyTo = policyTo;
    this.selectedCovers = selectedCovers;
  }
}

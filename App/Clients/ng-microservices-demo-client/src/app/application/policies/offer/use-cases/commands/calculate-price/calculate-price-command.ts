import { AutoMap } from '@automapper/classes';
import { QuestionAnswerModel } from '../../../models/question-answer-model';
export class CalculatePriceCommand {
  @AutoMap()
  productCode: string;

  @AutoMap()
  policyFrom: Date;

  @AutoMap()
  policyTo: Date;

  @AutoMap()
  selectedCovers: string[];

  @AutoMap()
  answers: QuestionAnswerModel[];

  constructor(productCode: string, policyFrom: Date, policyTo: Date, selectedCovers: string[], answers: QuestionAnswerModel[]) {
    this.productCode = productCode;
    this.policyFrom = policyFrom;
    this.policyTo = policyTo;
    this.selectedCovers = selectedCovers;
    this.answers = answers;
  }
}

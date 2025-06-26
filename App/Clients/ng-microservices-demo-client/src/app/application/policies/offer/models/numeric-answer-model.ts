import { AutoMap } from "@automapper/classes"
import { AnswerModelGeneric } from "./answer-model";
import { QuestionType } from "../../../enums/question-type";

export class NumericAnswerModel extends AnswerModelGeneric<number> {
  constructor(questionCode?: string, answer?: number) {
    super();    
    if (questionCode) this.questionCode = questionCode;
    if (answer !== undefined) this.answerValue = answer;
  }

  override get questionType(): QuestionType {
    return QuestionType.Numeric;
  }
}

import { QuestionType } from "../../../enums/question-type";
import { QuestionAnswerModelGeneric } from "./question-answer-model";

export class NumericQuestionAnswerModel extends QuestionAnswerModelGeneric<number> {
  constructor(questionCode: string, answer: number) {
    super();
    this.questionCode = questionCode;
    this.answer = answer;
  }
  override get questionType(): QuestionType {
    return QuestionType.Numeric;
  }
}

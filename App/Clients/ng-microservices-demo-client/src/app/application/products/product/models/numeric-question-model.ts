import { QuestionType } from "../../../enums/question-type";
import { QuestionModel } from "./question-model";

export class NumericQuestionModel extends QuestionModel {
  constructor(
    questionCode: string,
    index: number,
    text: string
  ) {
    super(questionCode, index, text);
  }

  get questionType(): QuestionType {
    return QuestionType.Numeric;
  }
}

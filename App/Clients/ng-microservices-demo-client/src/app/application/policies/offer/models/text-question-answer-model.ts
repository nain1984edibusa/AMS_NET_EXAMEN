import { QuestionType } from "../../../enums/question-type";
import { QuestionAnswerModelGeneric } from "./question-answer-model";

export class TextQuestionAnswerModel extends QuestionAnswerModelGeneric<string> {
  constructor(questionCode: string, answer: string) {
    super();
    this.questionCode = questionCode;
    this.answer = answer;
  }
  override get questionType(): QuestionType {
    return QuestionType.Text;
  }
}

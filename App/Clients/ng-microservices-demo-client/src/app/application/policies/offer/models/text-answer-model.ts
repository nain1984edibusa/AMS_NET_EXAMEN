import { AutoMap } from "@automapper/classes"
import { AnswerModelGeneric } from "./answer-model";
import { QuestionType } from "../../../enums/question-type";

export class TextAnswerModel extends AnswerModelGeneric<string> {
  constructor(questionCode?: string, answer?: string) {
    super();    
    if (questionCode) this.questionCode = questionCode;
    if (answer) this.answerValue = answer;
  }

  override get questionType(): QuestionType {
    return QuestionType.Text;
  }
}
